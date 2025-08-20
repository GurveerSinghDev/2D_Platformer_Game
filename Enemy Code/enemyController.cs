using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{


public Animator animator;
public enemyHealthBar eHealthBar;
public int maxEnemyHealth = 100;
public int currentEnemyHealth; 
[SerializeField] private AudioSource enemyDeathSound;



    
    void Start()
    {
        currentEnemyHealth = maxEnemyHealth;
        eHealthBar.SetMaxHealth(maxEnemyHealth);

       animator = GetComponent<Animator>();

        
    }
    void Die(){
    Debug.Log("Enemy Died!"); 

    animator.SetBool("isDead",true); //triggers the parameter in the enemy animator to true.

     
   GetComponentInParent<EnemyFollow>().enabled = false; //disables the following scripts, so the enemy doesn't move after dying.
   GetComponent<meleeEnemy>().enabled = false;
 
}
public void TakeDamage(int  enemyDamage){
    currentEnemyHealth -= enemyDamage; //enemy dmg is applied to enemies current Hp

    animator.SetTrigger("Hurt"); //applies trigger in enemy animator every time enemy is hurt
    eHealthBar.SetHealth(currentEnemyHealth);

    if (currentEnemyHealth <= 0){ //if enemy reaches 0, it will die
        Die();  //uses the die() function
        enemyDeathSound.Play();  //sound of enemy when it dies
    }


}

    
}



