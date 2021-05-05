using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AnvilMovement : MonoBehaviour
{
    // Movement Variables
    [SerializeField] float turnSpeed;
    [SerializeField] float thrust;

    //Base Stats
    [SerializeField] float health;

    //RigidBody
    Rigidbody rb;
    RigidbodyConstraints lockYZ;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lockYZ = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }

    
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.freezeRotation = true;
            transform.Rotate(new Vector3(-1, 0, 0) * turnSpeed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            rb.freezeRotation = true;
            transform.Rotate(new Vector3(1, 0, 0) * turnSpeed * Time.deltaTime);
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrust);
        }
    }
}
