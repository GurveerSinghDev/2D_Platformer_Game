using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Run : StateMachineBehaviour
{ 
    //References
    Transform player;  
    Rigidbody2D rb;
    bossController bc;


    //variables
    public float speed = 10f;
    public float attackRange = 3f;

 
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      player = GameObject.FindGameObjectWithTag("Player").transform;  //this allows the boss to move to the player only
      rb = animator.GetComponent<Rigidbody2D>();   //calling all refernces
      bc = animator.GetComponent<bossController>();

    }

   
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bc.turnToPlayer();

                                  //rb.position.y variable is not changed, because I dont want the boss to move up or down.
        Vector2 target = new Vector2(player.position.x, rb.position.y);  //finds players position, player position.x moves horinztoally towards the player.
        Vector2 newPos =  Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos); //allows the boss to actually move towards to the player physically

        if(Vector2.Distance(player.position, rb.position)  <= attackRange){
           animator.SetTrigger("Attack");        //created a variable, if player is within it the animator sets the animation to attack
           

        }
    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");  //resets the trigger, as I do no want the boss to be stuck in this trigger state.
        
    }

   

   
}
