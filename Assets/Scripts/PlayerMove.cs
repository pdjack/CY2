using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    
    private InputSystem_Actions _inputActions;
    private Rigidbody2D _rb;
    private Animator _animator;
    
    private Vector2 _movement;
    
    private void Awake()
    {
        _inputActions = new InputSystem_Actions();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
    }

    void Update()
    {
        PlayerInput();
    }

    void FixedUpdate()
    {
        Move();
    }

    void PlayerInput()
    {
        _movement = _inputActions.Player.Move.ReadValue<Vector2>();
    }

    void Move()
    {
        _rb.MovePosition(_rb.position + _movement * (moveSpeed * Time.fixedDeltaTime));
        
        _animator.SetFloat("inputX", _movement.x);
        _animator.SetFloat("inputY", _movement.y);
        
        if (_movement.x != 0 || _movement.y != 0)
        {
            _animator.SetFloat("lastInputX", _movement.x);
            _animator.SetFloat("lastInputY", _movement.y);
            
        }
        
    }
    
}