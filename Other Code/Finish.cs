using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
   private AudioSource fSound;

    private void Start()
    {
        fSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.name == "character"){
            fSound.Play();
            Invoke("ComplishLvl", 1f);  //allows a small time duration in between collides with flag, so it doesnt transfer player instantly
                                        //makes it look better
    }
    }
    private void ComplishLvl(){     //this function is called above, when collides it goes to next scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }

    
}
