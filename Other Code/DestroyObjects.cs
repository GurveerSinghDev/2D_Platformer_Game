using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    public float timeAlive;
   
    void Awake()
    {
        Destroy(gameObject, timeAlive); //destroys slash projectile afer certain amount of time set in inspector.
    }

    
}
