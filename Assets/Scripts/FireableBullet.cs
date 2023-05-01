using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireableBullet : MonoBehaviour
{
   
    public float speed = 50f; // adjust this to control the bullet's speed
    private GameManager GM;
    private Rigidbody2D rb;
    private player PL;
    private UIManager UI;

    private void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        PL = GameObject.Find("player").GetComponent<player>();
        UI = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // destroy the bullet when it hits something
        if (collision.tag == "Enemy")
            PL.addScore(5);
        Destroy(gameObject);

    }
   
    private void Update()
    {
        if (GM.gameOver|| Input.GetKeyDown(KeyCode.Tab))

            Destroy(gameObject);
       
    }

}
