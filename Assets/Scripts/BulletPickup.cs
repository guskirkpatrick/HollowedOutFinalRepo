using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPickup : MonoBehaviour
{
    // Start is called before the first frame update
    private float flippy = 1;
    private float startY;
    private GameManager GM;
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        startY = transform.position.y;
        flippy = 1;
        Destroy(gameObject, 25f);

    }

    // Update is called once per frame
    void Update()
    {
        
        if (GM.gameOver)
            Destroy(gameObject);
        jiggle();
    }
    void jiggle()
    {
        if (flippy == 1)
        {
            transform.Translate(Vector3.down * Time.deltaTime);
            // Debug.Log(transform.position.y);
        }



        if (flippy == -1)
        {
            transform.Translate(Vector3.up * Time.deltaTime);

        }
        if (transform.position.y < (startY - .4f) || transform.position.y > (startY + .4f))
            flippy *= -1;

    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            destroy();
        }

    }

    void destroy()
    {
        Destroy(this.gameObject);
    }
}
