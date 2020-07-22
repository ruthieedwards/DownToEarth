using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject child;
    public Transform parent;
    public GameObject asteroidPrefab;
    public GameObject[] asteroidArray;
    public float minDistance = 5.0f;
    public float maxDistance = 20.0f;
    public float startWaitTime = 3.0f;
    public float WaitTimeSubtractAmount = 0.1f;
    private IEnumerator coroutine;
    
    void Start()
    {
        if (asteroidArray == null)
        asteroidArray = GameObject.FindGameObjectsWithTag("asteroid");

        // sets parent to Earf so the asteroid rotates with camera
        foreach (GameObject asteroid in asteroidArray)
        {
            child.transform.SetParent(parent);
        }

        coroutine = SpawnAsteroid(startWaitTime);
        StartCoroutine(coroutine);
    }

    private IEnumerator SpawnAsteroid(float startWaitTime)
    {
        while (true)
        {
                if (startWaitTime > .2)
                    {
                        // gradually increases the rate at which asteroids spawn, with a max of 5 asteroids/sec
                        startWaitTime -= WaitTimeSubtractAmount;
                    }

                Spawn();
                yield return new WaitForSeconds(startWaitTime);
        }
    }

    void Spawn()
    {
        // spawns an asteroid at a random point on a ring around the Earf
        float distance = Random.Range( minDistance, maxDistance );
        float angle = Random.Range( -Mathf.PI, Mathf.PI );

        Vector3 spawnPosition = gameObject.transform.position ;
        spawnPosition += new Vector3( Mathf.Cos( angle ), Mathf.Sin( angle ), 0) * distance;
        spawnPosition.x = Mathf.Clamp( spawnPosition.x, -50, 50 );
        spawnPosition.y = Mathf.Clamp( spawnPosition.y, -50, 50);

        GameObject newAsteroid = Instantiate(asteroidPrefab, spawnPosition, transform.rotation);
        // sets parent to Earf so the asteroid rotates with camera
        newAsteroid.transform.SetParent(parent);
    }

    void Update()
    {
        //spawn asteroids for debug purposes
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("pressed space");
            Spawn();
        }*/
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if( other.gameObject.tag == "asteroid" )
        {
            print(other.name + " collided with Earf");
            Destroy(other.gameObject);
        }
    }
}
