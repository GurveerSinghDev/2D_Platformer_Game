using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slashProjectile : MonoBehaviour
{
    public float slashSpeed = 20f;
    public Rigidbody2D rb;
    public int slashDmg = 50;
    
    void Start()
    {
       rb.velocity = transform.right * slashSpeed; 
      
        
    }
    void OnTriggerEnter2D(Collider2D hitInfo){    //created this so if slash hits enemy does dmg, and if it hits boss it does dmg, if it hits null nothing will happen,
     enemyController enemy =  hitInfo.GetComponent<enemyController>();
       if (enemy !=null)
       {  //deal dmg to enemy
        enemy.TakeDamage(slashDmg);
       }
       bossHealth bossEnemy = hitInfo.GetComponent<bossHealth>();
        if (bossEnemy != null)
        {
            // Deal damage to the boss
            bossEnemy.TakeDamage(slashDmg); 
        }
       
    }

   
}
