using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// kalla á rigidbody component fyrir hopp svo að spilari getur ekki hoppað nema hann sé á jörðinni
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
    public Vector3 jump; // Breyta til að láta bíl hoppa
    public float JumpForce = 2.0f;
    public bool GameOver;
    // Start is called before the first frame update
    void Start()
    {
        // breytur fyrir rigidbody,hopp og animations og hljóð
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 4.0f, 0.0f); // hérna skilgreinum við að hlutur hoppar upp
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

    }
    //bool breyta fyrir hvort spilari sé á jörð
    public bool isGrounded;
    // Update is called once per frame
    void Update()
    {
        // if skilyrði til að skoða ef spilari ýtir á space þá hoppum við og keyrum nokkrar breytur
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !GameOver)
        {
            rb.AddForce(jump * JumpForce, ForceMode.Impulse);
            isGrounded = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound,1.0f);
        }
    }

    // private void fall til að skoða collision á hlut og keyra breytur
    private void OnCollisionEnter(Collision collision)
    {
//hérna skoðum við hvort spilari sé á jörð
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            dirtParticle.Play();
        }else if (collision.gameObject.CompareTag("Obstacle"))
        {//hér skoðum við hvort spilari snertir hindrun og leik er lokið
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
