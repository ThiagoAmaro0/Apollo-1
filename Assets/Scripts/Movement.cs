using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _thrustForce;
    [SerializeField] private float _rotationForce;
    [SerializeField] private bool _isThrusting;
    private Rigidbody _rb;
    private float _torque;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        _rb.AddRelativeTorque(Vector3.forward * _torque);
        if (_isThrusting)
        {
            _rb.AddRelativeForce(Vector3.up * _thrustForce);
        }
    }
    private void OnThrust(InputValue ctx)
    {
        _isThrusting = ctx.isPressed;
    }

    private void OnRotate(InputValue ctx)
    {
        _torque = -ctx.Get<float>() * _rotationForce;
    }
}
