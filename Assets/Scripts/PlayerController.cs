using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public CharacterController Controller;
    public GameObject sword;
    public GameObject groundcheck;
    private Vector3 velocity;
    public LayerMask groundmask;
    private Animator anim;
    private float jumppower = 5;
    public float gravity;
    float angle;
    public float SlideSpeed;

    public int jumpsleft = 1;
    private float multiplier;
    private bool Isgrounded;
    public bool gameOver;
    int slidespeed;
    public float duration = 3;
    bool HasEquipped;
    bool CanReset = true;
    bool IsSprinting;
    bool IsNotMoving;
    bool AlreadyAttackMotion;
    bool WalkAble;
    bool Sliding;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         anim = sword.GetComponent<Animator>();
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

        Vector3 Pos = transform.right * InputX + transform.forward * InputZ;

        Controller.Move(Pos * speed * multiplier * Time.deltaTime);
  
        Controller.Move(velocity * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        if (InputX > 0 || InputZ > 0)
        {
            IsNotMoving = false;
        }
        else
        {
            IsNotMoving = true;
        }

        Isgrounded = Physics.Raycast(groundcheck.transform.position, Vector3.down, out RaycastHit hit, 1.2f, groundmask);

        if (Isgrounded)
        {
            angle = Vector3.Angle(hit.normal, Vector3.up);
            if(angle > 50)
            {
                slidespeed = 20;
            }
            WalkAble = angle <= 40f;

            if (!WalkAble)
            {
      
                Vector3 slope = Vector3.ProjectOnPlane(Vector3.down, hit.normal);
                velocity += slope * slidespeed * Time.deltaTime;
            }

            if (velocity.y < 0 && WalkAble && Sliding == false)
            {
                velocity.y = -2f; // Stick to ground
                velocity.x = 0f;
                velocity.z = 0f;
            }
        }

        if (Isgrounded && velocity.y < 0 && WalkAble == true)
        {
            velocity.y = -2f;
            
        }
        if (Input.GetButtonDown("Jump") && Isgrounded == true && angle < 45)
        {
            velocity.y = MathF.Sqrt(jumppower * -2 * gravity);       
            Isgrounded = false;
            velocity.x = 0f;
            velocity.z = 0f;
            jumpsleft = 1;

        }   
        else if(Input.GetKeyDown(KeyCode.Space) && Isgrounded == false && jumpsleft == 1)
        {
            velocity.y = MathF.Sqrt(jumppower * -2 * gravity);
            jumpsleft = 0;
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
         if (Input.GetKeyDown(KeyCode.LeftControl) && Sliding == false && Isgrounded == true)
        {
            Debug.Log("slide is clicked");

            Sliding = true;
        }
         if(Sliding == true && duration >=0)
        {
            Vector3 sliding;
            sliding = gameObject.transform.forward * 2;
            velocity = sliding * 2;
            duration -= Time.fixedDeltaTime;
            Debug.Log("Sliding");

        }
        else
        {
            Sliding = false;
            duration = 3f;
            Debug.Log("Reseted");
        }
    }

    void FightSystem()
    {
        if (Input.GetMouseButtonDown(0) && HasEquipped == true && IsSprinting == false && AlreadyAttackMotion == false  )
        {
            anim.SetTrigger("Attack1");
            AlreadyAttackMotion = true;
            StartCoroutine(WeaponCooldown());
        }
        else if(Input.GetMouseButtonDown(1) && HasEquipped == true && IsSprinting == false && AlreadyAttackMotion == false)
        {
            anim.SetTrigger("Attack2");
            StartCoroutine(ResetCoolDown());
            AlreadyAttackMotion = true;
        }
        if (Input.GetKeyDown(KeyCode.Q) && IsSprinting == false)
        {
            HasEquipped = !HasEquipped;
            anim.SetBool("Equip", HasEquipped);
        }
    }

    IEnumerator WeaponCooldown()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetTrigger("Attack1");
        AlreadyAttackMotion = false;
    }
    
    IEnumerator ResetCoolDown()
    { 
        yield return new WaitForSeconds(0.7f);
        anim.SetTrigger("Attack2");
        AlreadyAttackMotion = false;
    }
    
IEnumerator SlideCoolDown()
    {
        Vector3 sliding;
        sliding = gameObject.transform.forward * 2;
        velocity = sliding * 2;
        duration -= Time.fixedDeltaTime;
        yield return new WaitForSeconds(10f);
        Sliding = false;
    }


   

}
