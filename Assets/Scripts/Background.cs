 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

     [SerializeField] private GameObject Wall;
     [SerializeField] private int x = 0;
    
       private GameManager GM;
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.gameOver || Input.GetKeyDown(KeyCode.Tab))

            Destroy(gameObject);
    }

    //Spawns a new background object when the player hits the trigger 
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            {
                x++;
                Instantiate(Wall, new Vector3(0, x * -120, 0), Quaternion.Euler(0, 0, 90));
            }
    }
    
}
