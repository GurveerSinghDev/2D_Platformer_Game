using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeMovement : MonoBehaviour
{
    private float vertical;
    private float speed = 20f; //speed of climb
    private bool isRope;
    private bool climbing;

    [SerializeField] private Rigidbody2D rb;
    void Update()
    {
        vertical = Input.GetAxis("Vertical");

        if (isRope && Mathf.Abs(vertical)>0f){
            climbing = true;  //if player is on rope, and the player is moving up it climbs
        }else{
            rb.gravityScale = 1f; //affects jumping, if player isnt climbing, gravity scale set to normal
        }
    }
    private void FixedUpdate(){
        if(climbing){
            rb.gravityScale = 0f; //allows the player to climb vertically
            rb.velocity = new Vector2(rb.velocity.x, vertical*speed);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Rope")){   //if player collides with rope
            isRope = true;   //variable used in above if statement

        }

    }
      private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Rope")){
            isRope = false;    
            climbing = false;
            
        }

    }
    

}
