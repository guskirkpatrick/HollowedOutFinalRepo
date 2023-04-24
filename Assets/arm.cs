using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arm : MonoBehaviour
{
    Vector3 currentEulerAngles;
    Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        
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
