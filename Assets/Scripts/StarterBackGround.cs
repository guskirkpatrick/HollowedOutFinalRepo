using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterBackGround : MonoBehaviour
{

    [SerializeField] private GameObject Wall;
    [SerializeField] public int x = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

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
