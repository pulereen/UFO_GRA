using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

  
    Rigidbody2D rb2d;
    public float speed = 0;
    private int count = 0;
   
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * 15);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PickUp"))
        {
            count++; 
            Destroy(collision.gameObject);
         

        }
    }

    void UpdateScoreText()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
