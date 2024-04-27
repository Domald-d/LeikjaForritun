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
        //setjum currenthealth sem maxhealth til að byrja með max líf
        //náum í rigidbody,animator,hljóð,stiga töflu components
        currentHealth = maxHealth;
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        textar.gameObject.SetActive(false);
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

        //if skilyrði til að skoða hvort player er í invincible frames
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
        //input til að skjóta projectiles
        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
            PlaySound(ThrowCog);
        }

        //input til að tala við npc og fá dialog kassa upp og fá líka stiga töflu upp
        if (Input.GetKeyDown(KeyCode.X))
        {
            //notum raycast svo að þegar player þarf að vera að horfa á npc kall til að getað tala við hann og vera upp við hann
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
        //vector breyta fyrir rigidbody stöðu
        //náum í position og hraða og horizontal,vertical stöður
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    //fall til að breyta líf hjá spilara
    public void ChangeHealth(int amount)
    {
        //ef spilara tekur damage þá setjum við animation Hit í gang
        //og skoðum hvort spilari sé í invincible frames
        // ef ekki þá setjum við spilara í invincible frames
        if (amount < 0)
        {
            animator.SetTrigger("Hit");
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        //ef skilyrði ef líf verður jafnt eða minna en 0
        // þá deyr player og förum í death scenu
        if(currentHealth <= 0)
        {
            SceneManager.LoadScene(2);
        }
        //breytur fyrir líf bar í ui
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
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

        animator.SetTrigger("Launch");
    }

    //fall til að spila hljóð
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }



}
