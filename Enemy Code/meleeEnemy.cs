using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeEnemy : MonoBehaviour
{
    public float attackCD; // attack cool down for enemy
    public float attackRange; 
    [SerializeField]  private float bcDistance; //collider distance of range
    public int enemyAttackDamage;  
    [SerializeField] private BoxCollider2D bC; //box collider for the range of the enemy attacks
    [SerializeField] private LayerMask playerLayer;
    private float cdTimer = Mathf.Infinity; // cooldown timer
    private playerHealth pHealth;
    private EnemyFollow eFollow;
    
    

    private Animator animator;

    private void Awake(){
        animator = GetComponent<Animator>();
        eFollow = GetComponentInParent<EnemyFollow>();
       
    }

    private void Update(){
        cdTimer += Time.deltaTime;

        if(PlayerInSight())
        {
                                         //if the player is in sight the
            if (cdTimer >= attackCD){  //and if cooldowntimer is greater than or equal to the enemies
            cdTimer = 0;                 //attack cool down, the cooldown timer will be set to 0 and it will attack
            
            animator.SetTrigger("meleeAttack");
        }

         }
         if (eFollow != null)   //if the player is not in sight, the enemies routine of walking will enabled again
            eFollow.enabled = !PlayerInSight();
       

    
    
}
    public bool PlayerInSight(){              //box that is created, if the player enters they will be targeted

        RaycastHit2D hit =
         Physics2D.BoxCast(bC.bounds.center + transform.right * attackRange * transform.localScale.x * bcDistance,
       
       new Vector3(bC.bounds.size.x * attackRange, bC.bounds.size.y, bC.bounds.size.z ), 0,Vector2.left,0,playerLayer);

      if (hit.collider != null)
           pHealth = hit.transform.GetComponent<playerHealth>();


        return hit.collider != null; 
    }
private void OnDrawGizmos(){
    Gizmos.color = Color.red;
    Gizmos.DrawWireCube(bC.bounds.center + transform.right * attackRange * transform.localScale.x * bcDistance,
     new Vector3(bC.bounds.size.x * attackRange, bC.bounds.size.y, bC.bounds.size.z )); 
}
private void DamagePlayer(){
    if (PlayerInSight()){
        pHealth.TakeDamage(enemyAttackDamage); //player takes damage, if the enemy is inside the box created above.
        

    }

}


}
