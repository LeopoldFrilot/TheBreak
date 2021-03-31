using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public float speed = 2f;
    public bool started = false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(started)
        {
            transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, speed * Time.deltaTime);
        }
    }
}
