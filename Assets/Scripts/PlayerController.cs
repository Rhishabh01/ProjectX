using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    
    public Rigidbody playerRb;
    

    public Vector3 velocity;
    public float jumppower = 10;
    public int playerspeed;
    public float gravity;
    public GameObject sword;
    public bool Isgrounded;
    public bool gameOver;
   
  
    bool HasEquipped;

    private float CoolDown = 0.2f;
    private bool CanReset = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Animator anim = sword.GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        playerRb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {

        MoveSystem();
        FightSystem();
    }

    void MoveSystem()
    {
        Animator anim = sword.GetComponent<Animator>();

        float InputX = Input.GetAxis("Horizontal");
        float InputZ = Input.GetAxis("Vertical");

        playerRb.transform.Translate(Vector3.forward * InputZ * playerspeed * Time.deltaTime);
        playerRb.transform.Translate(Vector3.right * InputX * playerspeed * Time.deltaTime);
       
        if (Input.GetKeyDown(KeyCode.Space) && Isgrounded == true)
        {
            playerRb.AddForce(Vector3.up * jumppower,ForceMode.Impulse);
            Isgrounded = false;
        }
        
        if (Input.GetKeyDown(KeyCode.R) && CanReset == true)
        {
            Vector3 resetPos = new Vector3(0, 5, 0);
            playerRb.transform.position = resetPos;
            CanReset = false;
            StartCoroutine(ResetCoolDown());
        }
      
    }

    void FightSystem()
    {
        Animator anim = sword.GetComponent<Animator>();

        if (Input.GetMouseButtonDown(0) && HasEquipped == true)
        {
            anim.SetTrigger("Attack1");
            StartCoroutine(WeaponCooldown());

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
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("Attack2", false);
    }

    IEnumerator ResetCoolDown()
    {
        yield return new WaitForSeconds(CoolDown);
        CanReset = true;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.CompareTag("Ground"))
        {
            Isgrounded = true;
            
        }

       if(collision.gameObject.CompareTag("Enemy"))
        {
            gameOver = true;
        }
 
        
      
    }

}
