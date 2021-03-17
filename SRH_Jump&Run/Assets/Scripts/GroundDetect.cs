using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        Debug.DrawRay(groundDetection.position, Vector3.down, Color.red);
        Debug.Log(groundInfo.collider);
    }
}
