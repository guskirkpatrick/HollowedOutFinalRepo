using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireableBullet : MonoBehaviour
{
   
    public float speed = 5f; // adjust this to control the bullet's speed
    private GameManager GM;
    private Rigidbody2D rb;

    private void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = rb.transform.rotation * Vector2.right * speed;
       // rb.velocity = transform.right * speed; // set initial velocity to the bullet's right direction multiplied by speed
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // destroy the bullet when it hits something
        Destroy(gameObject);
    }
    
    private void Update()
    {
        if (GM.gameOver)
            Destroy(gameObject);
    }

}
