using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    //breytur fyrir �vin og stigat�flu
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
        //n�um � rigidbody og animator
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
        stig = 0;
        texti.text = "Stig: " + stig.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //if skilyr�i til a� checka hvort v�lmenni s� broken
        //if skilyr�i til a� checka hvor �ttina �vinur er a� labba og sn�r svo tilbaka
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
        //if skilyr�i til a� checka hvort v�lmenni er broken
        if (!broken)
        {
            return;
        }
        //vector breyta fyrir rigidbody sta�setningu
        Vector2 position = rigidbody2D.position;

        //if skilyr�i til a� sko�a hvort �vinur labbar vertical
        //�� setjum vi� animation til a� labba vertical
        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction; ;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        //else skilyr�i ef ekki vertical labb
        //�� l�tum vi� �vin nota animation til a� labba upp venjulega
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction; ;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }
        //notum rigidbody til a� hreyfa �vin
        rigidbody2D.MovePosition(position);
    }

    //collision fall til a� sko�a hvort �vinur snertir player
    //ef �vinur snertir player �� t�kum vi� l�f af player og spilum hlj��
    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
            player.PlaySound(takeDamage);
        }
    }

    //fall fyrir �vin ef vi� l�gum ��
    //b�tum stigi vi� stigaf�flu
    // og notum if skilyr�i til a� checka hvort stig eru 4 e�a meira og �� vinnum vi� leikin
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
