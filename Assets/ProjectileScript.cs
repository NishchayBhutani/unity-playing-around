using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("collieded");
        Destroy(gameObject);
    }
}
