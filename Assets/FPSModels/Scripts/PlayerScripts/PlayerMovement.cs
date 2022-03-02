using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController _characterController;

    private Vector3 _moveDirection;

    public float Speed
    {
        get
        {
            return _speed;
        }
        set
        {
            _speed = value;
        }
    }
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _gravity = 20f;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private float _verticalVelocity;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _moveDirection = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0f, Input.GetAxis(Axis.VERTICAL));

        _moveDirection = transform.TransformDirection(_moveDirection);
        _moveDirection *= _speed * Time.deltaTime;

        ApplyGravity();
        _characterController.Move(_moveDirection);
    }

    private void ApplyGravity()
    {
        _verticalVelocity -= _gravity * Time.deltaTime;

        Jump();

        _moveDirection.y = _verticalVelocity * Time.deltaTime;
    }

    private void Jump()
    {
        if(_characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _verticalVelocity = _jumpForce;
        }
    }
}
