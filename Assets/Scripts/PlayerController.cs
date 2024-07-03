using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    Vector2 playerInput;
    Vector2 moveDirection;

    public GameObject projectile;
    public float playerSpeed = 7.0f;
    public float sightDistance = 1.5f;
    public float projectileSpeed = 20f;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if(!Mathf.Approximately(playerInput.x, 0.0f) || !Mathf.Approximately(playerInput.y,0.0f)) {
            moveDirection.Set(playerInput.x, playerInput.y);
            moveDirection.Normalize();
        }
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + playerInput * playerSpeed * Time.deltaTime);     
        Debug.DrawRay(rb.position + Vector2.up * 0.2f, moveDirection * 2f, Color.red);   
    }

    void OnMove(InputValue inputValue) {
        playerInput = inputValue.Get<Vector2>();
    }

    void OnInteract() {
        RaycastHit2D hit = Physics2D.Raycast(rb.position + Vector2.up * 0.2f, moveDirection * 2f, LayerMask.GetMask("NPC"));
        if(hit.collider != null) {
            Debug.Log("raycast hit: " + hit.collider.gameObject.name);
            GameObject nonPlayableCharacter = hit.collider.gameObject;
            nonPlayableCharacter.GetComponent<NPCScript>().TriggerDialogue();
        }
    }

    void OnShoot() {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 shootDirection = (mousePosition - transform.position).normalized;
        Debug.Log(shootDirection);
        GameObject gameObject = Instantiate(projectile, transform.position, Quaternion.identity);
        gameObject.GetComponent<Rigidbody2D>().velocity = shootDirection * projectileSpeed;
    }
 }
 
