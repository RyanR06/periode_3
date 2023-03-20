using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float h;
    public float v;

    public float rotationX;
    public Vector3 mouse;
    public float sensitivity;
    public Transform cameraa;
    public float rotateX;
    public float rotateY;

    public Vector3 v3;
    public float speed;
    public bool onGround;
    public Rigidbody rb;
    public float jumpForce;
    public Vector3 jump;
    public Vector3 v2;

    public KeyCode pauseKey;
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0, jumpForce, 0);
    }
    private void OnCollisionExit(Collision collision)
    {
        onGround = false;
    }
    private void OnCollisionStay(Collision collision)
    {
        onGround = true;

    }

    public void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        rotateX = Input.GetAxis("Mouse X");
        rotateY = Input.GetAxis("Mouse Y");

        v3.x = h;
        v3.z = v;

        mouse.y = rotateX;
        v2.x = -rotateY;

        transform.Translate(v3 * Time.deltaTime * speed);
        transform.Rotate(mouse * Time.deltaTime * sensitivity);
        cameraa.transform.Rotate(v2 * Time.deltaTime * sensitivity);

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            onGround = false;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10f;
        }
        else
        {
            speed = 5;
        }

        if (Input.GetKeyDown(pauseKey))
        {
            if(Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

}
