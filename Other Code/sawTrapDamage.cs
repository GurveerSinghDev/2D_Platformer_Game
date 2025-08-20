using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sawTrapDamage : MonoBehaviour
{
    [SerializeField] private int sawDamage;
    

   private void OnTriggerEnter2D(Collider2D collision){
     if (collision.tag == "Player")  //opposite of Health Pickup, reversed it.
      collision.GetComponent<playerHealth>().TakeDamage(sawDamage);
    
     //would be better if it did continuous damage if player stayed in range of it.
     //right now, it only does damage after every touch

   }
}
