using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    //breytur fyrir óvin og stigatöflu
    public float speed;
    bool broken = true;
    public ParticleSystem smokeEffect;
    public static int stig;

    Rigidbody2D rigidbody2D;
    Animator animator;
    public bool vertical;
    public float changeTime = 3.0f;
    float timer;
    int direction = 1;
    public AudioClip takeDamage;
    public TextMeshProUGUI texti;
    // Start is called before the first frame update
    void Start()
    {
        //náum í rigidbody og animator
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
        stig = 0;
        texti.text = "Stig: " + stig.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //if skilyrði til að checka hvort vélmenni sé broken
        //if skilyrði til að checka hvor áttina óvinur er að labba og snýr svo tilbaka
        if (!broken)
        {
            return;
        }
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    void FixedUpdate()
    {
        //if skilyrði til að checka hvort vélmenni er broken
        if (!broken)
        {
            return;
        }
        //vector breyta fyrir rigidbody staðsetningu
        Vector2 position = rigidbody2D.position;

        //if skilyrði til að skoða hvort óvinur labbar vertical
        //þá setjum við animation til að labba vertical
        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction; ;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        //else skilyrði ef ekki vertical labb
        //þá látum við óvin nota animation til að labba upp venjulega
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction; ;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }
        //notum rigidbody til að hreyfa óvin
        rigidbody2D.MovePosition(position);
    }

    //collision fall til að skoða hvort óvinur snertir player
    //ef óvinur snertir player þá tökum við líf af player og spilum hljóð
    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
            player.PlaySound(takeDamage);
        }
    }

    //fall fyrir óvin ef við lögum þá
    //bætum stigi við stigaföflu
    // og notum if skilyrði til að checka hvort stig eru 4 eða meira og þá vinnum við leikin
    public void Fix()
    {
        broken = false;
        rigidbody2D.simulated = false;
        smokeEffect.Stop();
        stig += 1;
        texti.text = "Stig: " + stig.ToString();
        if(stig >= 4)
        {
            SceneManager.LoadScene(3);
        }
    }
}
