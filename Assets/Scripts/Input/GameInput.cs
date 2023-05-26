using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    public event Action OnTouchStarted;

    private PlayerInput m_playerInput;

    private void Awake()
    {
        Instance = this;
        m_playerInput = new PlayerInput();
        m_playerInput.Jump.Touch.performed += Touch_performed;
    }

    private void Touch_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnTouchStarted?.Invoke();
    }


    private void OnEnable()
    {
        m_playerInput.Enable();
    }

    private void OnDisable()
    {
        m_playerInput.Disable();
    }
}
