using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteController : MonoBehaviour
{
    public bool facingRight = true;

    void Start()
    {
    }

    void Update()
    {
        Vector3 localScale = transform.localScale;
        
        if (Input.GetAxis("Horizontal") > 0)
        {
            GetComponent<Animator>().SetFloat ("cameraRotatingDirection", 1.0f);
            facingRight = true;
        }
        
        if (Input.GetAxis("Horizontal") < 0)
        {
            GetComponent<Animator>().SetFloat ("cameraRotatingDirection", 1.0f);
            facingRight = false;
        }

        if (Input.GetAxis("Horizontal") == 0) 
        {
            GetComponent<Animator>().SetFloat ("cameraRotatingDirection", 0.0f);
        }

        // flips the player sprite based on movement direction
        if ( ((facingRight) && (localScale.x < 0 )) || ((!facingRight) && (localScale.x > 0 )) ) 
        {
            localScale.x *= -1;
        }

        transform.localScale = localScale;

    }
}
