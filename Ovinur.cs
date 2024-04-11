using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;
using TMPro;
using System.Diagnostics.Tracing;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Ovinur : MonoBehaviour
{
    //public og private breytur fyrir líf texta og meira
    public static int health = 30;
    public Transform player;
    private  TextMeshProUGUI texti;
    private TextMeshProUGUI countText;
    private Rigidbody rb;
    private Vector3 movement;
    public float hradi = 5f;
    private Kassi kb;
    // Start is called before the first frame update
    void Start()
    {
        //næ í texta objects og rigid body
        health = 30;
        texti= GameObject.Find("Text2").GetComponent<TextMeshProUGUI>();
        countText = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();
        rb = this.GetComponent<Rigidbody>();
        texti.text = "Líf: " + health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // set positions á vector 3 notað fyrir óvini til að labba á player
       Vector3 stefna = player.position - transform.position;
        stefna.Normalize();
        movement = stefna;
    }
    private void FixedUpdate()
    {
        // köllum á Hreyfing fall til að labba á player
        Hreyfing(movement);
    }
    void Hreyfing(Vector3 stefna)
    {
        //látum óvini labba á player
        rb.MovePosition(transform.position + (stefna * hradi * Time.deltaTime));
    }

    public void OnCollisionEnter(Collision collision)
    {
        //skoðum hvort óvinur rekst á spilara 
        //og fjarlægum óvin og tökum líf frá spilara
        if (collision.collider.tag=="Player")
        {
            Debug.Log("Leikmaður fær í sig óvin");
            TakeDamage(10);
            gameObject.SetActive(false);
        }
        if (collision.collider.tag == "kula")
        {
            //ef óvinur fær í sig kúlu þá eyðum við óvin og bætum stig
            Debug.Log("Skotinn");
            gameObject.SetActive(false);
            Kassi.count = Kassi.count+ 5;
            SetCountText();
        }
    }
    public void TakeDamage(int damage)
    {
        //fall til að taka líf af spilara þegar óvinur snertir spilara
        //ef spilari er með 0 eða minna líf þá deyr hann og förum í death senu
        Debug.Log("health er núna" + (health).ToString());
        health -= damage;
        texti.text = "Líf: " + health.ToString();
        if (health <= 0)
        {
            SceneManager.LoadScene(2);
            //Bullet.count = 0;//núll stilli stigin 
            texti.text = "Líf: " + health.ToString();
        }

    }
    public void SetCountText()
    {
        //fall fyrir stiga gjöf
        countText.text = "Stig: " + Kassi.count.ToString();
    }


}
