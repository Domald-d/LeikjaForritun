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
    //n� � restart manager klasan �r restart manager scriptinu
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
        //n� �  rigidbody component fyrir hopp
        // n� � leikjar objecti� restart manager
        rb = GetComponent<Rigidbody>();
        rManager = GameObject.Find("Restart Manager").GetComponent<RestartManager>();
        jump = new Vector3(0.0f, 4.0f, 0.0f);
        Debug.Log("byrja");
        // stig og l�f texti �g set ��r � start til a� score og l�f birtist � level 2 og 3 �n �ess a� �urfa a� collida v� hlut
        countText.text = "Stig: " + count.ToString();
        livesText.text = "Lifes: " + lives.ToString();
        //kalla � restart manager til a� leikur byrji
        rManager.startGame();

    }
    //bool breyta fyrir hopp
    public bool isGrounded;
    // Update is called once per frame
    void FixedUpdate()
    {
        //nota if skilyr�i til a� sko�a ef bool breyta er true �� getum vi� hreyft spilara
        if (rManager.isGameActive)
        {
            if (Input.GetKey(KeyCode.UpArrow))//�fram
            {
                transform.position += -transform.forward * speed;
            }
            if (Input.GetKey(KeyCode.DownArrow))// til baka
            {
                transform.position += transform.forward * speed;

            }
            if (Input.GetKey(KeyCode.RightArrow))//h�gri
            {
                transform.position += transform.right * sideways;
            }
            if (Input.GetKey(KeyCode.LeftArrow))//vinstri
            {
                //hreyfir player um sideways � hvert skipti sem �tt er � leftArrow
                transform.position += -transform.right * sideways;
            }
            if (Input.GetKey(KeyCode.Space) && isGrounded)
            {
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
            //h�r r�tti �g playerinn vi� ef hann dettur
            //sn� player
            if (Input.GetKey("f"))
            {
                transform.Rotate(new Vector3(0, 5, 0));
            }
            if (Input.GetKey("g"))//sn�a leikmanni
            {
                transform.Rotate(new Vector3(0, -5, 0));
            }
            if (Input.GetKey("q"))// ef �tt er � q
            {
                transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }
        }
        

        if (transform.position.y <= -1)
        {
            //nota if skilyr�i til a� sko�a ef spilari dettur af mappinu er hann me� meira en 0 l�f
            if (lives > 0)
            {
                daudur();
                Endurr�sa();
            }
            //ef spilari er me� minna en 0 l�f �� er leik loki� og k�llum � gameOver a�fer� � Restart manager
            else
            {
                rManager.gameOver();
            }

        }

    }

    void OnCollisionEnter(Collision collision)
    {
        // ef player keyrir � object sem heitir hlutur
        if(collision.collider.tag == "ground")
        {
            isGrounded = true;
        }
        if (collision.collider.tag == "hlutur")
        {
            collision.collider.gameObject.SetActive(false);
            count = count + 1;
            // Debug.Log("N� er �g komin me� " + count);
            SetCountText();//kallar � falli�
        }
        if (collision.collider.tag == "peningur")
        {
            collision.collider.gameObject.SetActive(false);
            count = count + 5;
            //Debug.Log("N� er �g komin me� " + count);
            SetCountText();//kallar � falli�
        }
        if (collision.collider.tag == "Hindrun")
        {
            collision.collider.gameObject.SetActive(false);
            count = count - 2;
            lives = lives - 1;
            //Debug.Log("N� er �g komin me� " + count);
            SetCountText();//kallar � falli�
            setLifeText();
        }
        //collision fall fyrir l�f peninga
        if (collision.collider.tag == "Lif")
        {
            collision.collider.gameObject.SetActive(false);
            lives = lives + 1;
            setLifeText();
        }
    }

    // nytt method sem me�h�ndlar player dau�a
    void daudur()
    {
        this.enabled = false;
        countText.text = "Dau�ur";
        StartCoroutine(Bida());
        lives = lives - 1;
        setLifeText();
    }
    
    // fall til a� h�kka e�a l�kka stig
    public void SetCountText()
    {
        countText.text = "Stig: " + count.ToString();

    }
    //fall til a� h�kka e�a l�kk l�f
    // notum l�ka if skilyr�i til a� sko�a er l�f minna en 0 og ef svo �� er leik loki�
    public void setLifeText()
    {
        livesText.text = "Lifes: " + lives.ToString();
        if(lives < 0)
        {
            rManager.gameOver();
        }
    }

    //fall til bi�a a�eins �egar spilari deyr �� er sm� cool down
    IEnumerator Bida()
    {
        yield return new WaitForSeconds(3);
        Endurr�sa();
    }

    public void Byrja()
    {
        SceneManager.LoadScene(1);
    }
    //fall til a� endurr�sa level ef spilari dettur af mappi
    public void Endurr�sa()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//Level_1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}