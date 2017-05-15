using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    public Rigidbody myBody;
    public Vector3 force;
    public float maxSpeed;
    public float acceleration;
    public float jumpAcceleration;
    private bool isGrounded = false;

    void FixedUpdate()
    {
        ConstantMove();
    }

    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        isGrounded = true;
    }
    void OnCollisionExit(Collision collisionInfo)
    {
        isGrounded = false;
    }
    
    /// <summary>
    /// this function moves the ball on z axis
    /// </summary>
    void ConstantMove()
    {
        Vector3 newVelosity = myBody.velocity;

        //don't move with higher speed than maxSpeed
        if (myBody.velocity.z >= maxSpeed)
        {          
            newVelosity.z = maxSpeed;         
        }

        //acceleration to max speed
        else
        {
            newVelosity.z = newVelosity.z + acceleration;         
        }

        myBody.velocity = newVelosity;
    }

    /// <summary>
    /// make the player jupm
    /// </summary>
    void Jump()
    {
        Vector3 jumpVelosity = myBody.velocity;
        jumpVelosity.y = jumpVelosity.y + jumpAcceleration;
        myBody.velocity = jumpVelosity;
    }
	

}
