using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSlash : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private AudioSource swordSlash;
    private playerController pc;
    
    void Awake(){
         pc = GetComponent<playerController>(); //calling in script
    }

    void Update()
    {
       if (Input.GetKeyDown(KeyCode.P)){
            pc.Slash();  //if player presses p, animation will get played from playerController script and it plays a sound.
            swordSlash.Play();
        }
    }
    

}