using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

     [SerializeField] private GameObject Wall;
    private int x = 0;
    private bool triggerCheck = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    // I am working on the below section -Travis 
    private void OnTriggerExit2D(Collider2D other)
    {
            if (other.tag == "Player")
            {
                x += 1;
                Instantiate(Wall, new Vector3(0, x * -120, 0), Quaternion.Euler(0, 0, 90));
            }
    }
    
}
