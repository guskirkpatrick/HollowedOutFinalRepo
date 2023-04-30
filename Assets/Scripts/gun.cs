using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    // Start is called before the first frame update
    //float rotationSpeed = 60;
    Vector3 currentEulerAngles;
    Quaternion rotation;

    [SerializeField] private GameObject BulletPrefab = null;
   

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate();
      //  Flip();
      
    }
   
    //instantiate bullet prefab relative to ransform rotation of gun
    public void Shoot()
    {
       
        Quaternion adjustedRotation = rotation * Quaternion.Euler(0, 0, -90);
        Instantiate(BulletPrefab, transform.position + transform.right, adjustedRotation);

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
     * 
     */
}
