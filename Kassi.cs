using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Kassi : MonoBehaviour
{
 //breytur fyrir stig og sprengingu og texta
    public static int count = 0;
    public GameObject sprenging;
    private TextMeshProUGUI countText;
    void Start()
    {
        //náum í texta object
        countText = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();
        //sprenging= GetComponent<Explosion>
        count = 0;
        countText.text = "Stig: " + count.ToString();
    }
    private void Update()
    {//ef kassi er fyrir neðan y position -10 þá eyðum við kassanum
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "kula")
        {
            //skoðum hvort kassi fær í sig kúlu
            //eyðum objectinu og bætum við stigi og spilum sprengju effect
            Destroy(gameObject);
            gameObject.SetActive(false);
            Debug.Log("varð fyrir kúlu");
            count = count + 1;//færð stig
            SetCountText();//kallar í aðferðina
            Sprengin();
        }
    }
    public void SetCountText()//hér er aðferðin
    {
        //fall fyrir stiga gjöf
        countText.text = "Stig: " +Kassi.count.ToString();
    }
    void Sprengin()
    {
        //fall sem spilar sprengju effect
        Instantiate(sprenging, transform.position, transform.rotation);
    }
}
