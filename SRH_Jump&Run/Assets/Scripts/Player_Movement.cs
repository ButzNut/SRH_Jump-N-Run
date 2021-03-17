using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed;
    public float jump_Force;

    Rigidbody rb;

    public bool IsGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float x_movement = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(x_movement, 0);
        rb.velocity = new Vector2(x_movement * speed, rb.velocity.y);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, 1 * jump_Force);
            IsGrounded = false;
        }
    }

    #region Trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            IsGrounded = true;
        }

        if (other.gameObject.tag == "Enemy")
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
