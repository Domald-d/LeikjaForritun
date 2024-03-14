using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// kalla � rigidbody component fyrir hopp svo a� spilari getur ekki hoppa� nema hann s� � j�r�inni
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    // private og public breytur fyrir spilara t.d rigidbody audio og meira
    private Rigidbody rb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public Vector3 jump; // Breyta til a� l�ta b�l hoppa
    public float JumpForce = 2.0f;
    public bool GameOver;
    // Start is called before the first frame update
    void Start()
    {
        // breytur fyrir rigidbody,hopp og animations og hlj��
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 4.0f, 0.0f); // h�rna skilgreinum vi� a� hlutur hoppar upp
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

    }
    //breyta fyrir hvort spilari s� � j�r�
    public bool isGrounded;
    // Update is called once per frame
    void Update()
    {
        // if skilyr�i til a� sko�a ef spilari �tir � space �� hoppum vi� og keyrum nokkrar breytur
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !GameOver)
        {
            rb.AddForce(jump * JumpForce, ForceMode.Impulse);
            isGrounded = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound,1.0f);
        }
    }

    // private void fall til a� sko�a collision � hlut og keyra breytur
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            dirtParticle.Play();
        }else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            GameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
