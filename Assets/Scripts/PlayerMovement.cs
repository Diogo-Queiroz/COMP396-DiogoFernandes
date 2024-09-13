using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _speed = 6f;
    private Rigidbody _rigidbody;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(inputX, 0f, inputZ) * _speed;

        _rigidbody.velocity = movement;
    }
}
