using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disappearObject : MonoBehaviour
{
    [SerializeField] private AudioSource warningSound;

    private void OnTriggerEnter2D(Collider2D collision){
     if (collision.tag == "Player")  {
       warningSound.Play();
        Invoke("Missing", 1f);
     }
      
    }
    private void Missing(){
        gameObject.SetActive(false);
    }
}
