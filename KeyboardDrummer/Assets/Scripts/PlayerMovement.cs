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

        if (movement.x > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (movement.x < 0 && isFacingRight)
        {
            Flip();
        }
    }

    private void ApplyMovement()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }    

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        GetComponent<SpriteRenderer>().flipX = !isFacingRight;
    }
}