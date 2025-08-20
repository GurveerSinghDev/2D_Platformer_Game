using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossController : MonoBehaviour
{
    //refernce to player
    public Transform player;

    public bool turn = false; //turn set to false

    public void turnToPlayer(){

        Vector3 turned = transform.localScale;
        turned.z *= -1f;

        if(transform.position.x > player.position.x && turn){ //if bosess position is value is greater than the players value it will turn

            transform.localScale = turned;
            transform.Rotate(0f,180f,0f);  //changes boss to change on the x axis
            turn = false;  //setting boss turn to false
        }
        else if(transform.position.x < player.position.x && !turn){

            transform.localScale = turned;
            transform.Rotate(0f, 180f, 0f); //changes boss to change on the x axis
            turn = true; //setting turn to true
        }
    }
}
