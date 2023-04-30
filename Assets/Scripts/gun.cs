using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; 
    [SerializeField] private GameObject bulletStart;
    [SerializeField] private GameObject player;
    private float bulletSpeed = 30.0f;
    private GameManager GM;
    private player PL;
    private Vector3 target;

    public Camera cam;

    /// <summary>
    /// extra variables
    /// </summary>
    /// 
    
    //Vector2 direction;
       // float distance;
    void Start()
    {
        cam = Camera.main;
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        PL = player.GetComponent<player>();

    }

    // Update is called once per frame
    void Update()
    {
        target = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        Vector3 difference = target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        // player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if (Input.GetKeyDown(KeyCode.Mouse0) && PL.bullets > 0 && !GM.paused)
            {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            fireBullet(direction, rotationZ);
        }
    }
   
    //instantiate bullet prefab relative to ransform rotation of gun
    public void fireBullet(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = bulletStart.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ-90.0f);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        // Quaternion adjustedRotation = rotation * Quaternion.Euler(0, 0, -90);
        // Instantiate(BulletPrefab, spawnPoint.position, Quaternion.identity).Init(transform.up);

    }



    //rotates the parent gun object to players cursor
    /* void Rotate()
     {
         Vector2 Dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
         float Angle =Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg;
     rotation = Quaternion.AngleAxis(Angle, Vector3.forward);
         transform.rotation = rotation;
     }*/

    /* protected void Flip()
     {
         if () //angle >90 &&<360
         {
             m_FacingRight = false;
             transform.localRotation = Quaternion.Euler(0, 180, 0);
         }
         else
         {
             m_FacingRight = true;
             transform.localRotation = Quaternion.Euler(0, 0, 0);
         }
     }
     /*
      * 
      *   currentEulerAngles += new Vector3(0, 0, z) * Time.deltaTime * rotationSpeed;
         transform.localEulerAngles =currentEulerAngles;
         TurnX();
      * 
      * //Rotate();
         //  Flip();
         // var
        //  mousePosition.z = 0;
         // var dir = mousePosition - transform.position;
         //  transform.up= Vector3.MoveTowards(transform.up, dir, rotationSpeed * Time.deltaTime);

         //spawnPoint = (transform.position.x,transform.position.y,0f);

      */
}
