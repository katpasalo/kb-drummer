using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public Animator animator;

    [Header("Functional Options")]
    [SerializeField] private bool canMove = true;
    [SerializeField] private bool canSelect = true;

    [Header("Controls")]
    [SerializeField] private KeyCode selectKey = KeyCode.Return;

    [Header("Movement Parameters")]
    [SerializeField] private float moveSpeed = 0.5f;

    private bool isFacingRight = true;
    private Vector2 interactionRange = new Vector2(0.1f,1f);
    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        if (canMove) {HandleMovement();}
        if (canSelect && Input.GetKeyDown(selectKey)) {HandleSelection();}
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

    private void HandleSelection()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, interactionRange, 0, Vector2.zero);

        if(hits.Length > 0)
        {
            foreach(RaycastHit2D rc in hits)
            {
                if(rc.transform.GetComponent<MainMenuOption>())
                {
                    rc.transform.GetComponent<MainMenuOption>().Select();
                    return;
                }
            }
        }
    }
}