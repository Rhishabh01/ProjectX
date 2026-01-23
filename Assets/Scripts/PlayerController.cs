using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public int playerspeed;
    public Rigidbody playerRb;
    private CameraFollow came;
    public float jumppower = 10;
    public bool Isgrounded;
    public bool gameOver;
    public float gravity;
    public Vector3 velocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        came = gameObject.GetComponent<CameraFollow>();
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
