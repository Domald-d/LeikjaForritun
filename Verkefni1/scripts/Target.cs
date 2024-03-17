using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
//private og public breytur fyrir stig,hraða,y,x hnit
    private Rigidbody targetRb;
    private GameManager gameManager;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorgue = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;
    public int pointValue;
    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
    // náum í rigidbody component og notum random fyrir hraða og spinn á hlutum
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
//fall fyrir músar klikk og skoðum hvort leikur sé í gangi og ef hann er í gangi Þá getum við eytt hlutum þegar við klikkum á þá
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
    // fall fyrir trigger á collision ef hlutur með tag fer í sensor þá er leik lokið
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad 1"))
        {
            gameManager.GameOver();
        }
    }
    // föll fyrir hraða á hlutum notum Vector aðferðir
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorgue, maxTorgue);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
