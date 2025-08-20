

using UnityEngine;

public class EnemyFollow : MonoBehaviour
{  
     //patrol points
    [SerializeField] private Transform leftSide; //left and right gizmos, enemy will walk from them.
    [SerializeField] private Transform rightSide; //the enemy will also wait at them for a specfic amount of time set in inspector

    //enemy 
    [SerializeField] private Transform targetEnemy;  

    //movement variables
    [SerializeField] private float speed;
    private Vector3 initialScale;
    private bool turningLeft;

    //idle for enemy AI
    [SerializeField] private float idleDura;
    private float idleTiming;

    //animator
    [SerializeField]private Animator animator;


      private void Awake()
    {
       initialScale = targetEnemy.localScale;
    }
    private void OnDisable()
    {
        animator.SetBool("moving", false); //when enemy is disabled, this function will change the animation
    }


     private void Update(){
        if (turningLeft)
        {
            if (targetEnemy.position.x >= leftSide.position.x)
                TurnInDirection(-1); //switches direction
            else
                TurnDirection();
        }
        else
        {
            if (targetEnemy.position.x <= rightSide.position.x)
                TurnInDirection(1);   //switches direction
            else
                TurnDirection();
        }
     }
      private void TurnInDirection(int _dir)
    {
        idleTiming = 0; //if the enemy idle starts again, the enemies animation will be set to moving
       animator.SetBool("moving",true);

       //Move in that direction
        targetEnemy.position = new Vector3(targetEnemy.position.x + Time.deltaTime * _dir * speed,
            targetEnemy.position.y, targetEnemy.position.z);

        //Make enemy face direction
        targetEnemy.localScale = new Vector3(Mathf.Abs(initialScale.x) * _dir,
            initialScale.y, initialScale.z);

        
    }
       private void TurnDirection()
    {
            animator.SetBool("moving",false);
             idleTiming += Time.deltaTime;

            if(idleTiming > idleDura)
            turningLeft = !turningLeft;
    }
    
    
     }
   

    

