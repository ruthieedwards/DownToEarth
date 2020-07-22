using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillWithAsteroid : MonoBehaviour
{
    public GameObject explosionPrefab;
    public Transform parent;
    public AudioSource randomSound;
    public AudioClip[] audioSources;
    void Start()
    {
    }
    void Update()
    { 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "asteroid" )
        {
            Vector3 spawnPosition = gameObject.transform.position ;
            GameObject explody = Instantiate(explosionPrefab, spawnPosition, transform.rotation);
            explody.transform.SetParent(parent);

            // plays a random explosion sound
            randomSound.clip = audioSources[Random.Range(0, audioSources.Length)];
            randomSound.Play ();
            

            Destroy(gameObject);
        }
    }
}
