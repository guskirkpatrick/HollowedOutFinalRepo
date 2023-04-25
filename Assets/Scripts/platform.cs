using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    private GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 20f);
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        //maybe timer?
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.gameOver)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("collision");
        if (collision.tag == "bullet")
        {
            Destroy(gameObject);
        }

    }
}
