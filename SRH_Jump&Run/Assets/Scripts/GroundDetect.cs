using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundDetect : MonoBehaviour
{
    public float speed;
    public float distance;

    public bool movingRight = true;

    public Transform groundDetection;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector3.down, distance);
        if (groundInfo == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (movingRight == true && collision.gameObject.tag != "Ground")
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            movingRight = false;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingRight = true;
        }

        if(collision.gameObject.tag == "Player" && collision.rigidbody.velocity.y >= 0)
        {
            SceneManager.LoadScene(0);
        }

    }
}
