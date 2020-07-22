     using UnityEngine;
     using System.Collections;
      
     public class DontDestroy : MonoBehaviour {
      
         void Awake ()
         {
            // keeps the music playing throughout all the scenes
            GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
            DontDestroyOnLoad(this.gameObject);
         }
     }