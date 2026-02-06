using Unity.Mathematics;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    private Rigidbody enemyRb;
    public float enemySpeed;
    public bool Rayhit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 Distance = (player.transform.position - enemyRb.transform.position);
        Vector3 lookDirect = (player.transform.localPosition).normalized;
        Vector3 Rot = (player.transform.position);

        gameObject.transform.LookAt(Rot, Vector3.up);
        enemyRb.transform.Translate(-lookDirect * enemySpeed * Time.deltaTime);


        Rayhit = Physics.SphereCast(enemyRb.transform.position, 5, Vector3.up,out RaycastHit hitInfo);
        
        if(Rayhit) 
        {
            gameObject.transform.LookAt(Rot, Vector3.up);
            enemyRb.transform.Translate(-lookDirect * enemySpeed * Time.deltaTime);
        }
        else
        {
            gameObject.transform.LookAt(Rot, Vector3.up);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(-10);
        }
    }

}
