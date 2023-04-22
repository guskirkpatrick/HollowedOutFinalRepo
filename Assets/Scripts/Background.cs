using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

     [SerializeField] private GameObject Wall;
    //[Range(-1f,1f)]
    //public float scrollSpeed = 0.5f;
    //private float offset;
    //private Material mat;
    // Start is called before the first frame update
    void Start()
    {
        //mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        //offset += (Time.deltaTime * scrollSpeed) / 10f;
        //mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }

    // I am working on the below section -Travis 
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Instantiate(Wall,new Vector3(0,-120,0), Quaternion.Euler(0,0,90));
        }
    }
    
}
