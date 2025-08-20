using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossHealth : MonoBehaviour
{
    public Animator animator;
    public int maxBossHealth = 100; //setting the bosses max health
    public int currentBossHealth;
   public bossHealthbar bHealthBar; //calling health bar script
   public GameObject chestObject;
   public GameObject flagObject;
     

    void Start(){
        currentBossHealth = maxBossHealth;
        bHealthBar.SetMaxHealth(maxBossHealth);
       animator = GetComponent<Animator>();
    }
    void Die(){
        animator.SetBool("isDead",true); //changing the the state of boss
        Debug.Log("BOSS DEAD!!!");
        chestObject.SetActive(true);
        flagObject.SetActive(true);
        Destroy(gameObject); //remove boss from game

    }
    public void TakeDamage(int bossDamage){  
        currentBossHealth -= bossDamage;   //bosses hp, when it takes damage, it will trigger hurt

         animator.SetTrigger("Hurt");
        

        bHealthBar.SetHealth(currentBossHealth);

         if (currentBossHealth <= 0){ //if boss recaches 0 hp, it will the Die function that was created above.
        Die();  
        
        
    }

    }
}
