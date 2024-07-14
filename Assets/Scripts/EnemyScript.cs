using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    Rigidbody2D rb;
    bool isInShootCooldown = false;
    float currentShootCooldownTime;
    public float visionRadius = 5f;
    public LayerMask playerLayerMask;
    public float enemyMoveSpeed = 7f;
    public GameObject projectile;
    public float projectileSpeed = 20f;
    public float shootCooldownTime = 2f;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(isInShootCooldown) {
            currentShootCooldownTime -= Time.deltaTime;
            if(currentShootCooldownTime <= 0) {
                isInShootCooldown = false;
            }
        }
    }

    void FixedUpdate() {
        Collider2D hitCollider = Physics2D.OverlapCircle(transform.position, visionRadius, playerLayerMask);
        if(hitCollider != null) {
            Debug.Log("player detected by enemy");
            Vector2 positionToBeMoved = hitCollider.gameObject.transform.position - transform.position;
            positionToBeMoved.Normalize();
            rb.MovePosition(rb.position + (positionToBeMoved) * Time.deltaTime * enemyMoveSpeed);
            if(!isInShootCooldown) {
                GameObject proj = Instantiate(projectile, transform.position, Quaternion.identity);
                proj.GetComponent<Rigidbody2D>().velocity = positionToBeMoved * projectileSpeed;
                currentShootCooldownTime = shootCooldownTime;
                isInShootCooldown = true;
            }
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
    }
}