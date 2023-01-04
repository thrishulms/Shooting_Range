using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerActions _playerInput;
    private PlayerActions.OnFootActions _onFootActions;
    private PlayerMotor _playerMotor;

    // Start is called before the first frame update
    void Awake()
    {
        _playerInput = new PlayerActions();
        _onFootActions = _playerInput.OnFoot;
        _playerMotor = GetComponent<PlayerMotor>();
        _onFootActions.Jump.performed += ctx => _playerMotor.Jump();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _playerMotor.ProcessMove(_onFootActions.Movement.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        _onFootActions.Enable();
    }

    private void OnDisable()
    {
        _onFootActions.Disable();
    }
}
