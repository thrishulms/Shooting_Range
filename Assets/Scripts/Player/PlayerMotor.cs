using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=rJqP5EesxLk&t=162s
public class PlayerMotor : MonoBehaviour
{
    private CharacterController _characterController;
    private Vector3 _playerVelocity;
    public float speed = 5f;
    private bool _isGrounded;
    private float gravity = -9.8f;
    private float jumpHeight = 3f;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        _isGrounded = _characterController.isGrounded;
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        _characterController.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        if (_isGrounded && _playerVelocity.y < 0)
            _playerVelocity.y = -2f;
        _playerVelocity.y += gravity * Time.deltaTime;
        _characterController.Move(_playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (_isGrounded)
        {
            _playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            Debug.Log(_playerVelocity);

        }
    }
}
