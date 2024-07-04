using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody thisRigidbody;
    public float jumpPower = 10;
    public float jumpInterval = 0.5f;
    private float jumpCooldown = 0;

    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update Cooldown
        jumpCooldown -= Time.deltaTime;
        bool canJump = jumpCooldown <= 0;
         
        //Jump!
        if(canJump)
        {
            jumpCooldown = jumpInterval;
        } 
        bool jumpInput = Input.GetKey(KeyCode.Space);
        if (jumpInput)
        {
            Jump();
        }
    }
        void OnCollisionEnter(Collision other)
    {
        OnCustomCollisionEnter(other.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        OnCustomCollisionEnter(other.gameObject);
    }

    void OnCustomCollisionEnter(GameObject other)
    {
        bool isSensor = other.CompareTag("Sensor");
        if (isSensor)
        {
            // Score!
            Debug.Log("Score!");
        }
        else
        {
            Debug.Log("Game over...");
        }
    }



    void Jump()
    {
        //reset cooldown
        jumpCooldown = jumpInterval;
        //apply force
        thisRigidbody.velocity = Vector3.zero;
        thisRigidbody.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse); 
    }
    }
    
