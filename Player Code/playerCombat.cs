using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackArea; 
    public float attackRng = 0.5f;
    public LayerMask eLayers;   
    public int attackDmg = 40;

    [SerializeField] private AudioSource attackSound;

    
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)){
            Attack();  // if key is pressed, it calls the attack function which is written below
            attackSound.Play(); //sword hit sound plays
        }
    }

    void Attack(){
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackArea.position, attackRng, eLayers);

        foreach(Collider2D enemyCollider in hitEnemies){
             // Check if the enemy has an enemyController script
        enemyController regularEnemy = enemyCollider.GetComponent<enemyController>();
        if (regularEnemy != null)
        {
            // Deal damage to the regular enemy
            regularEnemy.TakeDamage(attackDmg);
        }

        // Check if the enemy has a bossHealth script
        bossHealth bossEnemy = enemyCollider.GetComponent<bossHealth>();
        if (bossEnemy != null)
        {
            // Deal damage to the boss
            bossEnemy.TakeDamage(attackDmg);
        }
    }

    

    }   //shows collider when editing
    void OnDrawGizmosSelected(){
        if  (attackArea == null)
        return;

        Gizmos. DrawWireSphere(attackArea.position,attackRng);
    }

    
}
