using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RubyController : MonoBehaviour
{
    //public og private  og bool breytur fyrir spilara
    //hljóð breytur, rigidbody,animation breytur
    AudioSource audioSource;
    Rigidbody2D rigidbody2d;
    float horizontal;
    public float speed = 3.0f;
    float vertical;
    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);
    public GameObject Projectile;
    public AudioClip ThrowCog;
    // Start is called before the first frame update
    void Start()
    {
        //setjum currenthealth sem maxhealth til að byrja með max líf
        //náum í rigidbody,animator,hljóð,stiga töflu components
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //input til að hreyfa player upp og niður og vinsti,hægri
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        //vector breyta til að hreyfa sig
        Vector2 move = new Vector2(horizontal, vertical);

        //if skilyrði með math falli til að reikna út hvert player er að hreyfa sig
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            //set og normalize aðferðir fyrir að hreyfa player
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        //animations fyrir player
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        //input til að skjóta projectiles
        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
            PlaySound(ThrowCog);
        }
    }

    void FixedUpdate()
    {
        //vector breyta fyrir rigidbody stöðu
        //náum í position og hraða og horizontal,vertical stöður
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    //fall fyrir projectiles
    void Launch()
    {
        //búum til projectile game objects
        //notum instantiate aðferðir
        //notum animation þegar spilari skýtur
        GameObject projectileObject = Instantiate(Projectile, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);
        Destroy(projectileObject, 1.2f);//kúl eytt eftir 1.2sek

        animator.SetTrigger("Launch");
    }

    //fall til að spila hljóð
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }



}