using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed;
    public float jump_Force;

    Rigidbody rb;

    public bool IsGrounded;

    public bool falling;

    bool running;

    Animator anim;

    SpriteRenderer sprite;

    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        float x_movement = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(x_movement, 0);
        rb.velocity = new Vector2(x_movement * speed, rb.velocity.y);

        anim.SetBool("Run", running);
        anim.SetFloat("Speed", rb.velocity.x);

        if(x_movement < 0 && x_movement != 0)
        {
            running = true;
            sprite.flipX = true;
        }
        else if (x_movement > 0 && x_movement != 0)
        {
            running = true;
            sprite.flipX = false;
        }
        else if (x_movement == 0)
        {
            running = false;
        }


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, 1 * jump_Force);
            IsGrounded = false;
        }
        if (rb.velocity.y < 0)
            falling = true;
        else
            falling = false;
    }

    #region Trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            IsGrounded = true;
        }

        if (other.gameObject.tag == "Enemy" && falling == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, 1 * jump_Force);
            GameObject.Destroy(other.gameObject);
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            IsGrounded = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        IsGrounded = false;
    }
    #endregion
}
