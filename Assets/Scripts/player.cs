using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public float speed = 1.5f;
    public float jumpHeight = 1f;
    [SerializeField] private GameObject PlayerExplosion;
    [SerializeField] private GameObject BulletPrefab = null;
    [SerializeField] private int bullets = 5;
    [SerializeField] private int lives = 5;
    [SerializeField] Camera Camera2 = null;
    [SerializeField] Camera MainCamera = null;
    private Rigidbody2D rb;



    private UIManager UI;
    private GameManager GM;
    private SpawnManager SM;
    private GameObject gun;

    //illegal rotation stuff
    Vector3 currentEulerAngles;
    Quaternion rotation;
    /// <summary>
    /// /////////////////
    /// </summary>

    void Start()
    {

       // Camera2.enabled = false;
       // MainCamera.enabled = true;
        UI = GameObject.Find("Canvas").GetComponent<UIManager>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        SM = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();


        gun = GameObject.Find("gun");
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
    }

    void move()
    {

        //-1 to +1

        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);//float


        // float verticalInput = Input.GetAxis("Vertical");
        //  transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);

        //check velocity
     //   if (rb.velocity > 200f)
        //    rb.velocity = 199f;

    }

    void jump()
    {

        if (Input.GetKeyDown(KeyCode.Space)&&rb.velocity.y==0)
        {
            //Debug.Log("jump1");
            rb.AddForce(new Vector2(rb.velocity.x, jumpHeight*120));
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

            //rotation stuff
            // Vector2 Dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            //  float Angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg;
            //  rotation = Quaternion.AngleAxis(Angle, Vector3.forward);

            //  transform.rotation = rotation;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision");
        if (collision.tag == "spike")
        {
            //bounce
            rb.AddForce(new Vector2(rb.velocity.x, jumpHeight*0.1f));



            //start co-routine immunity

            lives--;
            UI.UpdateLives(lives);
            if (lives <= 0)
            {
             //  Camera2.enabled = true;
                GM.gameOver = true;
                Destroy(this.gameObject);
                Application.Quit();
            }
        }

        if (collision.tag == "BulletPickUp")
        {
            bullets++;
            UI.UpdateBullets(bullets);
        }
    }
}