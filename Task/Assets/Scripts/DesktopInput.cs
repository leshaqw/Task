using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DesktopInput : MonoBehaviour
{
    private Player _player;
    public GameInput _gameInput;

    private void Awake()
    {
        _gameInput = new GameInput();
        _gameInput.Enable();

        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _gameInput.GamePlay.Jump.performed += OnJump;
        _gameInput.GamePlay.Rotation.performed += OnRotate;
        _gameInput.GamePlay.Rotation.canceled += OffRotate;
        _gameInput.GamePlay.Move.performed += OnMove;
    }

    private void OnDisable()
    {
        _gameInput.GamePlay.Jump.performed -= OnJump;
        _gameInput.GamePlay.Rotation.performed -= OnRotate;
        _gameInput.GamePlay.Move.performed -= OnMove;
    }

    private void OnJump(InputAction.CallbackContext obj)
    {
        _player.Jump();
    }

    private void OnRotate(InputAction.CallbackContext obj)
    {
        _player.isRotate=true;
    }

    private void OffRotate(InputAction.CallbackContext obj)
    {
        _player.isRotate=false;
    }

    private void OnMove(InputAction.CallbackContext obj)
    {
        _player.Move();
    }

}
