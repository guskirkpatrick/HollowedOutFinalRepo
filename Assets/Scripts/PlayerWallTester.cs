using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallTester : MonoBehaviour
{
    private float OldWallCord = 0f;
    [SerializeField] private GameObject wall = null;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision with wall");
        //prints in the debug log to confirm we are here
        if (collision.tag == "wall")
        {
            Instantiate(wall, new Vector3(0, OldWallCord-120, 0), Quaternion.identity);
            OldWallCord -= 120;
        }
    }

}
