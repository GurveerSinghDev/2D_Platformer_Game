using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickup : MonoBehaviour
{
   [SerializeField] private int healthNumber;

   private void OnTriggerEnter2D(Collider2D collision){
     if (collision.tag == "Player")
     collision.GetComponent<playerHealth>().AddHealth(healthNumber);  //uses addHealth from playerhealth, with a private variable set in inspector.
     gameObject.SetActive(false);  //removes the object after collison

   }
}
