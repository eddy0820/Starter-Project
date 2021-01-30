using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    BoxCollider2D boxcollider2d;
    SpriteRenderer spriteRenderer;
    public Sprite sprite1;
    public Sprite sprite2;
    public float changeTime = 3.0f;
    float timer;
    int direction = 1;

    public Text scoreText;
    static int scoreValue;
    void Start()
    {
        timer = changeTime;
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxcollider2d = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    
        boxcollider2d.enabled = false;
        spriteRenderer.sprite = sprite2;
        scoreText.text = "0";
        scoreValue = 0;
    }

    void Update()
    {
        timer -= Time.deltaTime;
    
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }

        if(direction == -1)
        {
            boxcollider2d.enabled = true;
            spriteRenderer.sprite = sprite1;
        }
        else
        {
            boxcollider2d.enabled = false;
            spriteRenderer.sprite = sprite2;
        }
    }

    void FixedUpdate()
    {

        Vector2 position = rigidbody2D.position;
        
        position.y = position.y + Time.deltaTime * 1 * direction;
        
        rigidbody2D.MovePosition(position);


    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(other.gameObject);
        scoreValue++;
        scoreText.text = scoreValue.ToString();
    }
}
