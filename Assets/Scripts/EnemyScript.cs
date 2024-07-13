using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    bool isInAttackMode = false;
    Rigidbody2D rb;

    public float visionRadius = 5f;
    public LayerMask playerLayerMask;
    public float enemyMoveSpeed = 7f;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    void FixedUpdate() {
        Collider2D hitCollider = Physics2D.OverlapCircle(transform.position, visionRadius, playerLayerMask);
        if(hitCollider != null) {
            Debug.Log("player detected by enemy");
            Vector2 positionToBeMoved = hitCollider.gameObject.transform.position - transform.position;
            positionToBeMoved.Normalize();
            rb.MovePosition(rb.position + (positionToBeMoved) * Time.deltaTime * enemyMoveSpeed);
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
    }
}
