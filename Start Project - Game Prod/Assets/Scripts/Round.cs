using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigidbody2d.AddForce(new Vector2(0, 0.0008f));
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
        
    }
}
