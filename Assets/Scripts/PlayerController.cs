using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public CharacterController Controller;
    public GameObject sword;
    public GameObject groundcheck;
    public Vector3 velocity;
    public LayerMask groundmask;
    public float jumppower = 10;
    public float gravity;
    private float CoolDown = 0.2f;

    public int jumpsleft = 1;
    float multiplier;
    public int playerFall = 2;
    public bool Isgrounded;
    public bool gameOver;
    private bool Isplayinganim = false;

    bool Issprint;
    bool HasEquipped;
    bool CanReset = true;
    bool IsSprinting;
    bool IsNotMoving;
    bool AlreadyAttackMotion;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

        Animator anim = sword.GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
     
        
    }

    // Update is called once per frame
    void Update()
    { 
        MoveSystem();
        FightSystem();
    }

    void MoveSystem()
    {
        float speed = 10;
        
        Animator anim = sword.GetComponent<Animator>();

        float InputX = Input.GetAxis("Horizontal");
        float InputZ = Input.GetAxis("Vertical");

        Vector3 Move = transform.right * InputX + transform.forward * InputZ;

        Controller.Move(Move * speed * multiplier * Time.deltaTime);

       
       
        Controller.Move(velocity * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        Isgrounded = Physics.CheckSphere(groundcheck.transform.position, 1.2f, groundmask);

        
       if(Isgrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            Debug.Log("IsGrounded");
        }
        if (Input.GetButtonDown("Jump") && Isgrounded == true)
        {
            velocity.y = MathF.Sqrt(jumppower * -2 * gravity);   //    
            Isgrounded = false;
            jumpsleft = 1;

        }   
        else if(Input.GetKeyDown(KeyCode.Space) && Isgrounded == false && jumpsleft == 1)
        {
            velocity.y = MathF.Sqrt(jumppower * -2 * gravity);
            jumpsleft = 0;
        }
        if (InputX > 0 || InputZ > 0)
        {
            IsNotMoving = false;
        }
        else
        {
            IsNotMoving = true;
               
        }

        if (Input.GetKey(KeyCode.LeftShift) && Isgrounded == true && IsNotMoving == false)
        {
            anim.SetBool("IsSprint", true);
            multiplier = 2;
            IsSprinting = true;
        }
        else
        {
            anim.SetBool("IsSprint", false);
            IsSprinting = false;
            multiplier = 1;
        }



        if (Input.GetKeyDown(KeyCode.R) && CanReset == true)
        {

            gameObject.transform.position = new Vector3(0, 5, 0);
            CanReset = false;
            StartCoroutine(ResetCoolDown());
        }
      
    }

    void FightSystem()
    {
        Animator anim = sword.GetComponent<Animator>();

        if (Input.GetMouseButtonDown(0) && HasEquipped == true && IsSprinting == false && AlreadyAttackMotion == false)
        {
            anim.SetTrigger("Attack1");
            AlreadyAttackMotion = true;
            StartCoroutine(WeaponCooldown());
           

        }
        else if(Input.GetMouseButtonDown(1) && HasEquipped == true && IsSprinting == false && AlreadyAttackMotion == false)
        {
            anim.SetTrigger("Attack2");
           // StartCoroutine(WeaponCooldown());
            

        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            HasEquipped = !HasEquipped;
            anim.SetBool("Equip", HasEquipped);

        }
    }
    IEnumerator WeaponCooldown()
    {
        Animator anim = sword.GetComponent<Animator>();  
        yield return new WaitForSeconds(2f);
        anim.SetTrigger("Attack1");
        AlreadyAttackMotion = false;
    }

    IEnumerator ResetCoolDown()
    {
        yield return new WaitForSeconds(CoolDown);
        CanReset = true;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
      
        // fixing needed
       if (collision.gameObject.CompareTag("Enemy"))
        {
            gameOver = true;
            Debug.Log("Yea lil bro");
        }
 
   
      
    }

   

}
