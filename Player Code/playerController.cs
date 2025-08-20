using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{


    bool platformed = false;            //jump variables
    float platformCheckRadius = 0.2f;
    public LayerMask platformLayer;
    public Transform platformCheck; 
    public float jump; 


    public float totalSpeed;   //movement variables start 
    Rigidbody2D rb;
    Animator animator;
    bool lookRight;          // movement variables end

    //respawn
    private  Vector3 respawnPoint;
    public GameObject fallDetector;
    private playerHealth ph; 

    //audio
    [SerializeField] private AudioSource jumpSound;
    //[SerializeField] private AudioSource runningSound;

   //ranged attack = slashes
    public Transform slashPoint;
    public GameObject slashPrefab;//this
    public float nextSlash = 0f;
    public float slashRate = 0.5f;


//dashing code
    private bool canDash;
    private bool isDashing;
    private float dashingPower = 5f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    [SerializeField] private  TrailRenderer tr;


   
   
private void Awake(){
    ph = GetComponent<playerHealth>();
}

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
        animator = GetComponent<Animator>();
        respawnPoint = transform.position; //respawn point set to start
        lookRight = true;      //variable in turn() if this is true they will turn right and vice versa with added code
           
        
    }

    

    void Update(){
        if(isDashing){
            return;
        }
        if (platformed && Input.GetAxis("Jump")>0){    // jump codde
            platformed = false;
            animator.SetBool("onGround",platformed);
            rb.AddForce(new Vector2(0,jump)); 
            jumpSound.Play(); //plays sound when player jumps //jump code ends

            
        }
            if (SceneManager.GetActiveScene().name == "Level 3")
        {
            // Enable dash only in the target scene
            canDash = true;

             if(Input.GetKeyDown(KeyCode.O) && canDash){
            StartCoroutine(Dash());
        }
        else
        {
            // Disable dash in other scenes
            canDash = false;
        }
        
       
        }

    } //fallDetector code
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "FallDetector"){  //if player touches collider, with the code below they will teleport to respawn point
            RespawnAtStart(); //transform.position = respawnPoint; deleted this and added it as a function below
            ph.Respawn(); //adds 100hp
            
        }

    }
    public void RespawnAtStart(){
        transform.position = respawnPoint; // this function is called in OnTrigger2d above. I made this as a function, so it can be
                                                //called in other scripts

    }
    void turn(){

        lookRight = !lookRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1; // x=1 not flip, x= -1 flip
        transform.localScale = theScale;                         
    }
    public void Slash(){

        if(Time.time > nextSlash){
            
            nextSlash = Time.time + slashRate;
           
            if(lookRight){  
               
                Instantiate(slashPrefab, slashPoint.position,Quaternion.Euler (new Vector3 (0,0,0)));
              
                animator.SetTrigger("Slash");

            }else if(!lookRight){
               
                Instantiate(slashPrefab, slashPoint.position,Quaternion.Euler (new Vector3 (0,0,180f)));
                         animator.SetTrigger("Slash");

                         //allows player to slash in both directions

            }
        }
    }
    void FixedUpdate()
    {
        if(isDashing){
            return;
        }
        platformed = Physics2D.OverlapCircle(platformCheck.position,platformCheckRadius,platformLayer); //jump code
        animator.SetBool("onGround",platformed);
        animator.SetFloat("verticalSpeed",rb.velocity.y); // jump ends




        float movement  = Input.GetAxis("Horizontal");                   //movement
        animator.SetFloat("speed",Mathf.Abs(movement));

        rb.velocity = new Vector2(movement*totalSpeed, rb.velocity.y);

        if(movement >0 &&! lookRight){
            turn();    //uses the turn function based if movement and the player isnt looking right they will turn and vice versa.
        }
        else if (movement<0&&lookRight){
            turn();
        }
        
    }
    private IEnumerator Dash(){
        
        canDash = false;
        isDashing = true;
        float orignalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = orignalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
   

    
}
