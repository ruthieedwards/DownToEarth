﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

     public class KillCoconut : MonoBehaviour
     {
         public float TimeToLive = 2f;
         private void Start()
         {
             Destroy(gameObject, TimeToLive);
         }
     }