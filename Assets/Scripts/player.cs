using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public float speed = 1.5f;
    public float jumpHeight = 10f;
    [SerializeField] private GameObject PlayerExplosion;
    [SerializeField] private GameObject playerPrefab;
    
    [SerializeField] private int bullets = 5;
    [SerializeField] private int lives = 3;
   
  //  [SerializeField] Camera Camera2 = null;
  // [SerializeField] Camera MainCamera = null;
    [SerializeField] private AudioSource spikeSoundEffect;
    [SerializeField] private AudioSource shootSoundEffect;
    [SerializeField] private AudioSource bulletPickupSoundEffect;


    private Rigidbody2D rb;



    private UIManager UI;
    private GameManager GM;
    private SpawnManager SM;
    private GameObject gun;
    private gun GS=null;

    //illegal rotation stuff
    Vector3 currentEulerAngles;
    Quaternion rotation;
    /// <summary>
    /// /////////////////
    /// </summary>


    void Start()
    {

        UI = GameObject.Find("Canvas").GetComponent<UIManager>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        SM = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();


        gun = GameObject.Find("gun");
        GS = GameObject.Find("gun").GetComponent<gun>();
        SM.StartSpawn();
        UI.UpdateLives(lives);
        UI.UpdateBullets(bullets);

    
        rb = GetComponent<Rigidbody2D>();

        //float speed = rb.velocity.magnitude();
    }

    // Update is called once per frame
    void Update()
    {
        move();


        jump();
        shoot();
        if (Input.GetKeyDown(KeyCode.Tab))
            {
            reset();
        }
    }

    void move()
    {

        //-1 to +1
     
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);//float

    }

    void jump()
    {

        if (Input.GetKeyDown(KeyCode.Space)&&rb.velocity.y==0)
        {
            //Debug.Log("jump1");
            rb.AddForce(new Vector2(rb.velocity.x, 10));
        }
    }

    void shoot()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0 )&&bullets>0)
        {
            //Debug.Log("shoot");
           // rb.AddForce(new Vector2(rb.velocity.x, jumpHeight * 160));
            bullets--;
            UI.UpdateBullets(bullets);
            rb.AddForce(gun.transform.right * -1f * 630);
            if(GS!=null)
            GS.Shoot();


            //the below plays a sound when the gun is fired -Travis
            shootSoundEffect.Play();

          
        }
    }

    void reset()
    {
       
        transform.position = new Vector2(0, 2);
        bullets = 5;
        UI.UpdateBullets(bullets);
        lives = 3;
        UI.UpdateLives(lives);
        GM.paused = false;
        Time.timeScale = 1;
        //toggled part
       GM.gameOver = false;

        UI.SetGameOver(false);
        //add more stuff

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       // Debug.Log("collision");
        if (collision.tag == "spike")
        {
            //bounce
            if(rb.velocity.y>12.0)
                rb.AddForce(new Vector2(rb.velocity.y, jumpHeight * 150f));
            else
            rb.AddForce(new Vector2(rb.velocity.y, jumpHeight*100f));
           
            //start co-routine immunity

            lives--;
            UI.UpdateLives(lives);
            //The below plays a sound when player hits spikes -Travis
            spikeSoundEffect.Play();

            if (lives <= 0)
            {
             //  Camera2.enabled = true;
                
                //  playerPrefab.SpriteRenderer
              //  GameObject.Find("player").GetComponent<SpriteRenderer>().SetActive(false); 
               // GM.paused = true;
                GM.gameOver = true;

                ///Application.Quit();
            }
        }

        if (collision.tag == "BulletPickUp")
        {
            bullets++;
            UI.UpdateBullets(bullets);
            //the below plays a sound effect when bullet is picked up -Travis
            bulletPickupSoundEffect.Play();
        }

        //I am working on the below to spawn the background when triggered.
/*
        if (collision.tag == "BackgroundSpawnTrigger")
        {
            
        }
*/
    }
}
