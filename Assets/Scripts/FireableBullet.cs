using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireableBullet : MonoBehaviour
{
   
    public float speed = 5f; // adjust this to control the bullet's speed

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed; // set initial velocity to the bullet's right direction multiplied by speed
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // destroy the bullet when it hits something
        Destroy(gameObject);
    }

}
