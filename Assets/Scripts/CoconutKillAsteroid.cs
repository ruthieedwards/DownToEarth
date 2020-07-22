using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutKillAsteroid : MonoBehaviour
{
    public ScoringSystem scoringSystem;
    public GameObject explosionPrefab;
    public Transform parent;
    public AudioSource randomSound;
    public AudioClip[] audioSources;

    void Start()
    {
       scoringSystem = GameObject.Find("Main Camera").GetComponent<ScoringSystem> ();
    }

    void Update()
    {
        
    }

     void OnCollisionEnter2D(Collision2D col)
     {
        
        if( col.gameObject.tag == "asteroid" )
        {
            print(gameObject.name + " killed an asteroid ");
            scoringSystem.scoreNumber += 1;

            // if the coconut collides with an asteroid, the player earns a point and the asteroid explodes
            Vector3 spawnPosition = gameObject.transform.position ;
            GameObject explody = Instantiate(explosionPrefab, spawnPosition, transform.rotation);
            explody.transform.SetParent(parent);

            // plays a random explosion sound
            randomSound.clip = audioSources[Random.Range(0, audioSources.Length)];
            randomSound.Play ();

            // kills the asteroid (the coconut will die eventually according to KillCoconut script)
            Destroy(col.gameObject);
        } 
     
    }


}
