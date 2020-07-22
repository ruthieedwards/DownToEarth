using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject coconut;
    public GameObject player;
    public PlayerSpriteController playerScript;
    public bool playerFacingRight;
    public Transform coconutSpawn;
    public float fireDelay = 0.2f;
    public float timeLastShot = 0.0f;
    private Vector2 lookDirection;
    private float lookAngle;
    public float coconutVelocity = 20f;

    public float coconutSubtractAngle;
    public float subtractLookAngleAmount = 90f;
    public AudioSource randomSound;
    public AudioClip[] audioSources;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerSpriteController>();
    }

    void Fire ()
    {
        if (playerFacingRight == true)
        {
        // fires a coconut in the direction of the mouse
        GameObject firedCoconut = Instantiate (coconut, coconutSpawn.position, Quaternion.Euler(0.0f, 0.0f, lookAngle - coconutSubtractAngle));
        firedCoconut.GetComponent<Rigidbody2D>().velocity = coconutSpawn.right * coconutVelocity;
        }

        if (playerFacingRight == false)
        {
        GameObject firedCoconut = Instantiate (coconut, coconutSpawn.position, Quaternion.Euler(0.0f, 0.0f, lookAngle - coconutSubtractAngle));
        firedCoconut.GetComponent<Rigidbody2D>().velocity = -coconutSpawn.right * coconutVelocity;
        }
        
        // plays a random sound effect to keep the audio varied
        randomSound.clip = audioSources[Random.Range(0, audioSources.Length)];
        randomSound.Play ();
        
    }
    void Update()
    {
        playerFacingRight = playerScript.facingRight;

        if (playerFacingRight == true)
        {
            // gets mouse position, translates it to an angle, and rotates the gun
            lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, lookAngle - subtractLookAngleAmount);
        }

        if (playerFacingRight == false)
        {
            lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, lookAngle + 180 + subtractLookAngleAmount);
        }

        // controls the rate of fire
       if (Input.GetMouseButton(0) && (Time.time > timeLastShot + fireDelay) )
       {
            timeLastShot = Time.time;
            Fire();
       }
    }
}
