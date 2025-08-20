using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public int maxPlayerHealth = 100;
    public int currentPlayerHealth;
    public Animator animator;
  public playerHealthBar healthBar;
  private playerController pc;

  [SerializeField] private AudioSource hurtSound;
  [SerializeField] private AudioSource deathSound;

   
    private void Awake(){
    pc = GetComponent<playerController>(); 
}
    void Start()
    {
        currentPlayerHealth = maxPlayerHealth;
        healthBar.SetMaxHealth(maxPlayerHealth);
        
        animator = GetComponent<Animator>();

    }

                                         
        //testing damage on player
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I)){  
           TakeDamage(20);
       }
        
   }
    public void TakeDamage(int playerDamage){  
        currentPlayerHealth -= playerDamage; 

        healthBar.SetHealth(currentPlayerHealth);

        if (currentPlayerHealth > 0){
            animator.SetTrigger("Hurt");   //if player takes damage, hurt trigger plays
            hurtSound.Play();
        }
        else
                   
        {
            if(currentPlayerHealth <= 0)  //if player health is lower or equal to 0, player dies and respawns.
             {   
            animator.SetTrigger("Death");
            GetComponent<playerController>().enabled = false;
            pc.RespawnAtStart(); 
            Respawn(); 
           //deathSound.Play();
            
           
            }
        }


    } public void AddHealth(int playerAdd){
        currentPlayerHealth = playerAdd;   //this is also used in health pickups, useful function for respawining and gaining health
        healthBar.SetHealth(currentPlayerHealth);

    }
    public void Respawn(){ 
        AddHealth(maxPlayerHealth); //uses the variable of total health, when respawn it resets it health
       animator.ResetTrigger("Death"); 
         animator.Play("playerIdle");  
         deathSound.Play();
        GetComponent<playerController>().enabled = true; //added this so it enabled the user to play afer dying
         
    }
}
