using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    
    public Rigidbody playerRb;
    

    public Vector3 velocity;
    public float jumppower = 10;
    public int playerspeed;
    public float gravity;

    public bool Isgrounded;
    public bool gameOver;

    private float CoolDown = 2f;
    private bool CanReset = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        playerRb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {

        MoveSystem();
       
    }

    void MoveSystem()
    {
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
            playerRb.transform.position = new Vector3(0, 5, 0);
            CanReset = false;
            StartCoroutine(ResetCoolDown());
        }
        

    }

    IEnumerator ResetCoolDown()
    {
        yield return new WaitForSeconds(CoolDown);
        CanReset = true;
        Debug.Log(CoolDown);
        
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
