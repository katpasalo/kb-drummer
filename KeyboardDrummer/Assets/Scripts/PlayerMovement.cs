using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public Animator animator;

    [Header("Functional Options")]
    [SerializeField] private bool canMove = true;
    [SerializeField] private bool canInteract = true;

    [Header("Controls")]
    // [SerializeField] private KeyCode interactKey = KeyCode.KeypadEnter;

    [Header("Movement Parameters")]
    [SerializeField] private float moveSpeed = 0.5f;

    [Header("Interaction")]
    // private Interactable currentInteractable;

    // private bool isMoving = false;
    private bool isFacingRight = true;
    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        if (canMove) 
        {
            if (canInteract) 
            {
                // HandleInteractionCheck();
                // HandleInteractionInput();
            }

            HandleMovement();

        }        
    }

    void FixedUpdate()
    {
        ApplyMovement();
    }

    private void HandleMovement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // animator.SetFloat("Horizontal", movement.x);
        // animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        // If the input is moving the player right and the player is facing left...
        if (movement.x > 0 && !isFacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (movement.x < 0 && isFacingRight)
        {
            // ... flip the player.
            Flip();
        }
    }

    private void ApplyMovement()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }    

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        isFacingRight = !isFacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}