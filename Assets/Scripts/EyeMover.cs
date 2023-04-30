using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeMover : MonoBehaviour
{
    Vector3 currentEulerAngles;
    Quaternion rotation;
    [SerializeField] private GameObject eye;

    private GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        
    }

    void Rotate()
    {
        Vector2 Dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float Angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg;
        rotation = Quaternion.AngleAxis(Angle, Vector3.forward);
        transform.rotation = rotation;
    }
    
}
