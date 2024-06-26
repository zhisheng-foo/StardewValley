using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    [SerializeField] float speed = 2f;
    Vector2 motionVector;
    public Vector2 lastMotionVector;
    public bool moving;

    Animator animator;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    //Update() is called once per frame. This means it executes its content
    // every time the screen draws a new frame, which can vary depending on the frame rate of the game
    private void Update()
    {   
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //handle movement of character
        motionVector = new Vector2(
            horizontal,
            vertical
            );
        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);

        moving = horizontal != 0 || vertical != 0;
        animator.SetBool("moving", moving);

        if (moving) 
        {
            lastMotionVector = new Vector2(
                horizontal,
                vertical
            ).normalized;
            animator.SetFloat("lastHorizontal" , horizontal);
            animator.SetFloat("lastVertical", vertical);
        }

        //using Update() to adjust physics calculations can lead to inconsistences in gameplay
        //due to varying frame rate across different devices

        //however, it is ideal in the following condition
        //Gathering input from player
        //Triggering changes in animations
        // Updating game logic
    }

    //called upon on a fixed time interval, which aligns with the physics engine's updates
    //provide consistent operation across all machines regardless of frame rate
    void FixedUpdate()
    {
        Move();

        //suitable for physics calculations
        
    }

    private void Move() 
    {
        rigidbody2d.velocity = motionVector * speed;
    }
}
