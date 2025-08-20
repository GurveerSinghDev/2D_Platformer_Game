using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chestController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D chest){
     if (chest.tag == "Player")  {
       Invoke("loadScene",1f);
    }
      
    }
    private void loadScene(){
        SceneManager.LoadSceneAsync(4);
    }
    
}
