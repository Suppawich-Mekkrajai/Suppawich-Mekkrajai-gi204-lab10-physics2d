using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
     Rigidbody2D rb2d;
     private Vector2 moveInput; //for walk with addforce

     private float move;

     [SerializeField] private float speed;

     [SerializeField] float jumpForce;
     [SerializeField]  bool isJumping;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //walk with addforce
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb2d.AddForce(moveInput * speed);
        /*move = Input.GetAxis("Horizontal");
        
        rb2d.linearVelocity = new Vector2(move * speed, rb2d.linearVelocity.y);
        */
        
        if(Input.GetButtonDown("Jump") && isJumping)
        {
           rb2d.AddForce(new Vector2(rb2d.linearVelocity.x,jumpForce)); 
           Debug.Log("Jump!");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }

    
}
