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
        

        Vector3 lookDirect=( player.transform.localPosition).normalized;
       // enemyRb.transform.Translate(Rot * enemySpeed * Time.deltaTime);*/

       Vector3 Rot = (player.transform.position);
        gameObject.transform.LookAt(Rot);
        enemyRb.transform.Translate(-lookDirect * enemySpeed * Time.deltaTime);
        

        

    }
}
