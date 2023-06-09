using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 5;
    private bool movingRight=false;
    private GameManager GM;

    
    //[SerializeField] private AudioSource spawn;
    // Update is called once per frame
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        int random = Random.Range(0, 1);
        if (random == 0)
            movingRight = true;
       // spikeSoundEffect.Play();
        //spawn.Play();

    }
    void Update()
    {
        move();
        if(GM.gameOver || Input.GetKeyDown(KeyCode.Tab))
            Destroy(gameObject);


    }

    void move()
    {
        if (movingRight)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (transform.position.x >= 12f)
        {
            movingRight = false;
        }
        else if (transform.position.x <= -14f)
        {
            movingRight = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // destroy the bullet when it hits something
        if (collision.tag == "Player")

            Destroy(gameObject);

                else if (collision.tag == "Bullet")

            Destroy(gameObject);
        else
            movingRight= !movingRight;


    }
}
