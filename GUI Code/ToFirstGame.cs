using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToFirstGame : MonoBehaviour
{
      public void PlayGameButton(){
        SceneManager.LoadSceneAsync(1);
    }
}
