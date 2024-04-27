using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RubyController : MonoBehaviour
{
    //public og private  og bool breytur fyrir spilara
    //hlj�� breytur, rigidbody,animation breytur
    AudioSource audioSource;

    public int maxHealth = 5;
    public int currentHealth;
    public int health { get { return currentHealth; } }
    public float speed = 3.0f;
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);
    public GameObject Projectile;
    public AudioClip ThrowCog;
    public TextMeshProUGUI textar;
    // Start is called before the first frame update
    void Start()
    {
        //setjum currenthealth sem maxhealth til a� byrja me� max l�f
        //n�um � rigidbody,animator,hlj��,stiga t�flu components
        currentHealth = maxHealth;
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        textar.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //input til a� hreyfa player upp og ni�ur og vinsti,h�gri
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        //vector breyta til a� hreyfa sig
        Vector2 move = new Vector2(horizontal, vertical);

        //if skilyr�i me� math falli til a� reikna �t hvert player er a� hreyfa sig
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            //set og normalize a�fer�ir fyrir a� hreyfa player
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        //animations fyrir player
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        //if skilyr�i til a� sko�a hvort player er � invincible frames
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
        //input til a� skj�ta projectiles
        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
            PlaySound(ThrowCog);
        }

        //input til a� tala vi� npc og f� dialog kassa upp og f� l�ka stiga t�flu upp
        if (Input.GetKeyDown(KeyCode.X))
        {
            //notum raycast svo a� �egar player �arf a� vera a� horfa � npc kall til a� geta� tala vi� hann og vera upp vi� hann
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
                NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                if (character != null)
                {
                    character.DisplayDialog();
                    textar.gameObject.SetActive(true);
                }
            }
        }
    }

    void FixedUpdate()
    {
        //vector breyta fyrir rigidbody st��u
        //n�um � position og hra�a og horizontal,vertical st��ur
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    //fall til a� breyta l�f hj� spilara
    public void ChangeHealth(int amount)
    {
        //ef spilara tekur damage �� setjum vi� animation Hit � gang
        //og sko�um hvort spilari s� � invincible frames
        // ef ekki �� setjum vi� spilara � invincible frames
        if (amount < 0)
        {
            animator.SetTrigger("Hit");
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        //ef skilyr�i ef l�f ver�ur jafnt e�a minna en 0
        // �� deyr player og f�rum � death scenu
        if(currentHealth <= 0)
        {
            SceneManager.LoadScene(2);
        }
        //breytur fyrir l�f bar � ui
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
    }

    //fall fyrir projectiles
    void Launch()
    {
        //b�um til projectile game objects
        //notum instantiate a�fer�ir
        //notum animation �egar spilari sk�tur
        GameObject projectileObject = Instantiate(Projectile, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);

        animator.SetTrigger("Launch");
    }

    //fall til a� spila hlj��
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }



}
