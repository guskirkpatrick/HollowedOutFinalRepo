using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{

    public float speed = 1.5f;
    public float jumpHeight = 10f;
    [SerializeField] private GameObject PlayerExplosion;
    [SerializeField] private GameObject playerPrefab;
    
    [SerializeField] public int bullets = 5;
    [SerializeField] private int lives = 3;
  
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
        
            rb.AddForce(new Vector2(rb.velocity.x, 10));
        }
    }

    void shoot()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0 )&&bullets>0&&!GM.paused)
        {
 
            bullets--;
            UI.UpdateBullets(bullets);
            rb.AddForce(gun.transform.right * -1f * 630);
          //bullet shoot is now calculated seperately in the gun script


            //the below plays a sound when the gun is fired -Travis
            shootSoundEffect.Play();

          
        }
    }
    void toMenu()
    {
        SceneManager.LoadScene(0);
    }
   public void reset()
    {
       
        transform.position = new Vector2(0, 0);
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
            bullets+=2;
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
