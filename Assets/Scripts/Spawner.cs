using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //[SerializeField] private GameObject[] Platforms = null;
    //[SerializeField] private GameObject[] Spikes = null;


    [SerializeField] private GameObject spike = null;
    [SerializeField] private GameObject BulletPickUp = null;
    [SerializeField] private GameObject Enemy = null;
    [SerializeField] private GameObject player = null;
   // private Rigidbody2D RB;

  
    private GameManager GM;
    private float startY;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
       // startY = transform.pos;
        player = GameObject.Find("player");
       // RB = GameObject.Find("player").GetComponent<Rigidbody2D>();
        //finds game manager
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartSpawn()
    {
        //Debug.Log("check1");
        StartCoroutine(SpikeSpawnRoutine());
        StartCoroutine(BulletSpawnRoutine());
        StartCoroutine(EnemySpawnRoutine());
        //Debug.Log("check2");

    }
    IEnumerator SpikeSpawnRoutine()
    {
       
        while (true && player != null  ) // (GM.gameOver != null && !GM.gameOver&&spike!=null)
        {
            // Debug.Log("spike spawn");
            if( player.transform.position.y < 0.0f)
            Instantiate(spike, new Vector3(Random.Range(- 15.0f, 15.0f),
                Random.Range(player.transform.position.y - 30.0f, player.transform.position.y - 15.0f), 0), Quaternion.identity);
            yield return new WaitForSeconds(0.6f);
        }
    }

    IEnumerator BulletSpawnRoutine()
    {
        while (true && player != null)//&&RB.velocity.y!=0) // (GM.gameOver!=null&&!GM.gameOver&&BulletPickUp!=null)
                                       //find amount of platforms below

        {
            // int random = Random.Range(0, 3);
            //  Debug.Log(" bulletspawn");
            if (player.transform.position.y < 0.0f)
                Instantiate(BulletPickUp, new Vector3(Random.Range(-15.0f, 15.0f), Random.Range(player.transform.position.y - 40.0f, player.transform.position.y - 15.0f), 0), Quaternion.identity);
            yield return new WaitForSeconds(1.2f);
        }
    }

    IEnumerator EnemySpawnRoutine()
    {
        while (true && player != null)// && RB.velocity.y != 0) // (GM.gameOver!=null&&!GM.gameOver&&BulletPickUp!=null)
                                       //find amount of platforms below

        {
            // int random = Random.Range(0, 3);
            //  Debug.Log(" bulletspawn");
            if (player.transform.position.y < 0.0f)
                Instantiate(Enemy, new Vector3(Random.Range( - 15.0f,15.0f), Random.Range(player.transform.position.y - 30.0f, player.transform.position.y - 15.0f), 0), Quaternion.identity);
            yield return new WaitForSeconds(3.5f);
        }
    }
}