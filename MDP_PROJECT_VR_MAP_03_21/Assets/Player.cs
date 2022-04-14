using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rigidbody;

    public float force = 100.0f;
    public bool isBorder;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void StopToWall()
    {
        Debug.DrawRay(transform.position, transform.forward * 1, Color.green);
        isBorder = Physics.Raycast(transform.position , transform.forward , 1 , LayerMask.GetMask("Wall"));
    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rigidbody.AddForce(Vector3.up * force);
        }
    }
    private void Update()
    {
        StopToWall();
    }
}
