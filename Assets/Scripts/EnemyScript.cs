using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    bool isInAttackMode = false;

    public float visionRadius = 5f;
    public LayerMask playerLayerMask;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void FixedUpdate() {
        isInAttackMode = Physics2D.OverlapCircle(transform.position, visionRadius, playerLayerMask);
        if(isInAttackMode) {
            Debug.Log("player detected by enemy");
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
    }
}
