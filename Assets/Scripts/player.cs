using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{

    public float speed = 1.5f;
    public float jumpHeight = 10f;
  
    [SerializeField] private GameObject playerPrefab;
    
    [SerializeField] public int bullets = 5;
    [SerializeField] private int lives = 5;
    [SerializeField] private int permaScore=0;
    [SerializeField] private int tempScore = 0;
    [SerializeField] private AudioSource spikeSoundEffect;
    [SerializeField] private AudioSource shootSoundEffect;
    [SerializeField] private AudioSource bulletPickupSoundEffect;
    [SerializeField] private AudioSource EnemyDeath;


    //script accesors
    private Rigidbody2D rb;
    private UIManager UI;
    private GameManager GM;
    private SpawnManager SM;
    private GameObject gun;
    private StarterBackGround SBG;
    private gun GS=null;
    private float startY;

  



    void Start()
    {

        UI = GameObject.Find("Canvas").GetComponent<UIManager>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        SM = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        startY=transform.position.y;
        SBG = GameObject.Find("StarterWall").GetComponent<StarterBackGround>();
        gun = GameObject.Find("gun");
        GS = GameObject.Find("gun").GetComponent<gun>();
        SM.StartSpawn();
        UI.UpdateScore(0);
        UI.UpdateLives(lives);
        UI.UpdateBullets(bullets);

    
        rb = GetComponent<Rigidbody2D>();

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
        //needs work
        
            //addScore(5);

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

    public void addScore(int sco)
    {
        tempScore += sco;
        UI.UpdateScore(tempScore+permaScore);
    }
    public void CalculatePermaScore()
    {
        if(transform.position.y<permaScore)
            //cast to int
        {
            permaScore = (int) -transform.position.y;
        }
        UI.UpdateScore(tempScore + permaScore);
    }
   public void reset()
    {
       
        transform.position = new Vector2(0, 0);
        bullets = 5;
        permaScore = 0;
        tempScore= 0;
        UI.UpdateScore(0);
        UI.UpdateBullets(bullets);
        lives = 5;
        SBG.x = 0; 
        UI.UpdateLives(lives);
        GM.paused = false;
        Time.timeScale = 1;
        //toggled part
       GM.gameOver = false;

        UI.SetGameOver(false);
        
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
            lives--;
            UI.UpdateLives(lives);
            //The below plays a sound when player hits spikes -Travis
            spikeSoundEffect.Play();

            if (lives <= 0)
            {
             
                GM.gameOver = true;
            }
        }

        if (collision.tag == "BulletPickUp")
        {
            bullets+=3;
            UI.UpdateBullets(bullets);
            //the below plays a sound effect when bullet is picked up -Travis
            bulletPickupSoundEffect.Play();
        }

        if (collision.tag == "Enemy")
        {
            //bounce  
         
            lives--;
            UI.UpdateLives(lives);
            //The below plays a sound when player hits spikes -Travis
            EnemyDeath.Play();

            if(lives <= 0)
            {
                GM.gameOver = true;
            }
        }




    }
}
