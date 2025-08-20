using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAttack : MonoBehaviour
{
    public int atkDmg = 20; //attack damage variable can be changed in inspector
    public Vector3 atkOff;
    public float atkRng = 20f; //the range in where the boss see's the player and attacks
    public LayerMask attackMask;

    public void BossAttack(){

        Vector3 post = transform.position;

        post += transform.right * atkOff.x;
        post += transform.up * atkOff.y;

        Collider2D colData = Physics2D.OverlapCircle(post, atkRng, attackMask);

        if (colData != null){
            colData.GetComponent<playerHealth>().TakeDamage(atkDmg);   //if player is within the collider and range, it will call players healtj script
        }                                                                //and do dmg to players health, with the variable created above
    }
    void OnDrawGizmosSelected(){  //function shows the range on screen when editing.

        Vector3 post = transform.position;
        post += transform.right * atkOff.x;
        post += transform.up * atkOff.y;

        Gizmos.DrawWireSphere(post,atkRng);
    }
}
