using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //[SerializeField] private GameObject[] Platforms = null;
    //[SerializeField] private GameObject[] Spikes = null;


    [SerializeField] private GameObject spike = null;
    [SerializeField] private GameObject BulletPickUp = null;
    [SerializeField] private GameObject player = null;

    private int PlatformCount = 0;
    private GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("player");
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
        //Debug.Log("check2");

    }
    IEnumerator SpikeSpawnRoutine()
    {
        while (true && player != null) // (GM.gameOver != null && !GM.gameOver&&spike!=null)
        {
            // Debug.Log("spike spawn");
            Instantiate(spike, new Vector3(Random.Range(player.transform.position.x - 15.0f, player.transform.position.x + 15.0f),
                Random.Range(player.transform.position.y - 30.0f, player.transform.position.y - 15.0f), 0), Quaternion.identity);
            yield return new WaitForSeconds(0.3f);
        }
    }

    IEnumerator BulletSpawnRoutine()
    {
        while (true && player != null) // (GM.gameOver!=null&&!GM.gameOver&&BulletPickUp!=null)
                                       //find amount of platforms below

        {
            // int random = Random.Range(0, 3);
            //  Debug.Log(" bulletspawn");
            Instantiate(BulletPickUp, new Vector3(Random.Range(player.transform.position.x - 15.0f, player.transform.position.x + 15.0f), Random.Range(player.transform.position.y - 30.0f, player.transform.position.y - 15.0f), 0), Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
        }
    }
}