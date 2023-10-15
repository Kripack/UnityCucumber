using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jump;

    private Rigidbody2D rb;
    public GameObject sword;
    private float moveInput;
    private bool facingRight = true;
    private bool isGrounded;
    private bool isDoubled;
    public bool swordPickedUp;

    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    public LayerMask enemy;
    public Transform attackPos;
    public float attackRange;

    private Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if (moveInput == 0)
        {
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isRunning", true);
        }
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        
        if (isGrounded && Input.GetKeyDown (KeyCode.Space))
        {
            isDoubled = true;
            rb.velocity = Vector2.up * jump;
            animator.SetTrigger("TakeOf");
        }
        else if (isDoubled && Input.GetKeyDown (KeyCode.Space))
        {
            isDoubled = false;
            rb.velocity = Vector2.up * jump;
            
        }

        if (isGrounded == true)
        {
            animator.SetBool("isJumping", false);
        }
        else
        {
            animator.SetBool("isJumping", true);
        }

        if (swordPickedUp)
        {
            sword.SetActive(true);
        }
        else
        {
            sword.SetActive(false);
        }


        if (Input.GetMouseButton(0) && swordPickedUp)
        {
            animator.SetTrigger("Attack");
        }
          

    }

    public void OnAttack()
    {
        Collider2D[] enemys = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
        for (int i = 0; i < enemys.Length; i++)
        {
            Destroy(enemys[i].gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

        if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3 (0, 180, 0);
        }
        else if(moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
