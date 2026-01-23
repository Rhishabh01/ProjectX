using JetBrains.Rider.Unity.Editor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    private Rigidbody enemyRb;
    public float enemySpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
         Vector3 lookDirect=(player.transform.position - gameObject.transform.position).normalized;
         enemyRb.transform.Translate(lookDirect * enemySpeed * Time.deltaTime);

    }
}
