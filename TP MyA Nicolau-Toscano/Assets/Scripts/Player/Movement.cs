using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement 
{
    Transform _transform;
    float _speed;
    float _jumpForce;
    Rigidbody _rb;
    public Movement(Transform t, float speed, float jumpForce, Rigidbody rb)
    {
        _transform = t;
        _speed = speed;
        _jumpForce = jumpForce;
        _rb = rb;
    }
    public void Jump()
    {
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    public void Move(float h)
    {
        //_transform.position += _transform.right * h * _speed * Time.deltaTime;
        _transform.Translate(Vector3.forward * Time.deltaTime * _speed * h);

    }
}
