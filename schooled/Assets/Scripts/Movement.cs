using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{

    public float playerSpeed = 5;
    public float jumpHeight = 3;
    public float startSpeed;
    
    private float hor;
    private float vert;
    private Vector3 moveDirection;

    private Rigidbody rB;
    private Vector3 jump;
    private float jumpB;
    private bool midAir;

    void Start()
    {
        rB = GetComponent<Rigidbody>();

        startSpeed = playerSpeed;

        jump.y = jumpHeight;
    }


    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        moveDirection.x = hor;
        moveDirection.z = vert;
        transform.Translate(moveDirection * Time.deltaTime * playerSpeed);

        if (jumpB == 1)
        {
            rB.velocity = jump;
        }

        if (Input.GetKeyDown("space") && midAir)
        {
            rB.AddForce(jump * jumpHeight, ForceMode.Impulse);
        }

    }
    void OnCollisionStay(Collision collision)
    {
        if ( collision.gameObject.tag == "Ground")
        {
            midAir = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            midAir = false;
        }
    }

    public void Boost(float power, float time)
    {
        StartCoroutine(DoBoost(power, time));
    }

    private IEnumerator DoBoost (float power, float time)
    {
        playerSpeed *= power;
        yield return new WaitForSeconds(time);
        playerSpeed = startSpeed;
    }

}
