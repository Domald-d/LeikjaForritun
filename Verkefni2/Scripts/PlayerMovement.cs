using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using TMPro;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovment : MonoBehaviour
{
    // Start is called before the first frame update
    //private og public breytur fyrir player movement og fleiri hluti
    //næ í restart manager klasan úr restart manager scriptinu
    private RestartManager  rManager;
    public float speed = 0.2f;
    public float sideways = 0.2f;
    public Vector3 jump;
    public float jumpForce = 2;
    private Rigidbody rb;
    public static int count;
    public TextMeshProUGUI countText;
    public static int lives =3;
    public TextMeshProUGUI livesText;


    void Start()
    {
        //næ í  rigidbody component fyrir hopp
        // næ í leikjar objectið restart manager
        rb = GetComponent<Rigidbody>();
        rManager = GameObject.Find("Restart Manager").GetComponent<RestartManager>();
        jump = new Vector3(0.0f, 4.0f, 0.0f);
        Debug.Log("byrja");
        // stig og líf texti ég set þær í start til að score og líf birtist í level 2 og 3 án þess að þurfa að collida vð hlut
        countText.text = "Stig: " + count.ToString();
        livesText.text = "Lifes: " + lives.ToString();
        //kalla á restart manager til að leikur byrji
        rManager.startGame();

    }
    //bool breyta fyrir hopp
    public bool isGrounded;
    // Update is called once per frame
    void FixedUpdate()
    {
        //nota if skilyrði til að skoða ef bool breyta er true þá getum við hreyft spilara
        if (rManager.isGameActive)
        {
            if (Input.GetKey(KeyCode.UpArrow))//áfram
            {
                transform.position += -transform.forward * speed;
            }
            if (Input.GetKey(KeyCode.DownArrow))// til baka
            {
                transform.position += transform.forward * speed;

            }
            if (Input.GetKey(KeyCode.RightArrow))//hægri
            {
                transform.position += transform.right * sideways;
            }
            if (Input.GetKey(KeyCode.LeftArrow))//vinstri
            {
                //hreyfir player um sideways í hvert skipti sem ýtt er á leftArrow
                transform.position += -transform.right * sideways;
            }
            if (Input.GetKey(KeyCode.Space) && isGrounded)
            {
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
            //hér rétti ég playerinn við ef hann dettur
            //sný player
            if (Input.GetKey("f"))
            {
                transform.Rotate(new Vector3(0, 5, 0));
            }
            if (Input.GetKey("g"))//snúa leikmanni
            {
                transform.Rotate(new Vector3(0, -5, 0));
            }
            if (Input.GetKey("q"))// ef ýtt er á q
            {
                transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }
        }
        

        if (transform.position.y <= -1)
        {
            //nota if skilyrði til að skoða ef spilari dettur af mappinu er hann með meira en 0 líf
            if (lives > 0)
            {
                daudur();
                Endurræsa();
            }
            //ef spilari er með minna en 0 líf þá er leik lokið og köllum á gameOver aðferð í Restart manager
            else
            {
                rManager.gameOver();
            }

        }

    }

    void OnCollisionEnter(Collision collision)
    {
        // ef player keyrir á object sem heitir hlutur
        if(collision.collider.tag == "ground")
        {
            isGrounded = true;
        }
        if (collision.collider.tag == "hlutur")
        {
            collision.collider.gameObject.SetActive(false);
            count = count + 1;
            // Debug.Log("Nú er ég komin með " + count);
            SetCountText();//kallar á fallið
        }
        if (collision.collider.tag == "peningur")
        {
            collision.collider.gameObject.SetActive(false);
            count = count + 5;
            //Debug.Log("Nú er ég komin með " + count);
            SetCountText();//kallar á fallið
        }
        if (collision.collider.tag == "Hindrun")
        {
            collision.collider.gameObject.SetActive(false);
            count = count - 2;
            lives = lives - 1;
            //Debug.Log("Nú er ég komin með " + count);
            SetCountText();//kallar á fallið
            setLifeText();
        }
        //collision fall fyrir líf peninga
        if (collision.collider.tag == "Lif")
        {
            collision.collider.gameObject.SetActive(false);
            lives = lives + 1;
            setLifeText();
        }
    }

    // nytt method sem meðhöndlar player dauða
    void daudur()
    {
        this.enabled = false;
        countText.text = "Dauður";
        StartCoroutine(Bida());
        lives = lives - 1;
        setLifeText();
    }
    
    // fall til að hækka eða lækka stig
    public void SetCountText()
    {
        countText.text = "Stig: " + count.ToString();

    }
    //fall til að hækka eða lækk líf
    // notum líka if skilyrði til að skoða er líf minna en 0 og ef svo þá er leik lokið
    public void setLifeText()
    {
        livesText.text = "Lifes: " + lives.ToString();
        if(lives < 0)
        {
            rManager.gameOver();
        }
    }

    //fall til biða aðeins þegar spilari deyr þá er smá cool down
    IEnumerator Bida()
    {
        yield return new WaitForSeconds(3);
        Endurræsa();
    }

    public void Byrja()
    {
        SceneManager.LoadScene(1);
    }
    //fall til að endurræsa level ef spilari dettur af mappi
    public void Endurræsa()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//Level_1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}