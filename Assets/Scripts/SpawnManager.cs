using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Platforms = null;
    
    [SerializeField] private GameObject[] Spikes = null;
    private GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        //finds game manager
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSpawn()
    {
        StartCoroutine(SpikeSpawnRoutine());
        StartCoroutine(PlatformSpawnRoutine());
    }
    IEnumerator SpikeSpawnRoutine()
    {
        while (!GM.gameOver)
        {
            int random = Random.Range(0, 3);
            Instantiate(Spikes[random], new Vector3(Random.Range(-6.5f, +6.5f), 6.5f, 0), Quaternion.identity);
            yield return new WaitForSeconds(25.0f);
        }
    }

    IEnumerator PlatformSpawnRoutine()
    {
         while (!GM.gameOver)
             //find amount of platforms below is not equal to 
         {
             int random = Random.Range(0, 3);
             Instantiate(Platforms[random], new Vector3(Random.Range(-5.0f, +5.0f), 6.5f, 0), Quaternion.identity);
             yield return new WaitForSeconds(20.0f);
         }
    }
}
