using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public float speed = 10.0f;
    private Vector2 target;
    private Vector2 position;

    void Start()
    {
        // targets the center of the Earf
        target = new Vector2(0.0f, -12.81f);
        position = gameObject.transform.position;
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, target, step);
    }

     

    
}
