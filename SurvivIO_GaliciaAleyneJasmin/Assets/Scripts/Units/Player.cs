using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    [SerializeField] private Joystick _movementJoystick;
    [SerializeField] private Joystick _aimingJoystick;

    private float _horizontalMove;
    private float _verticalMove;
    private Vector3 _movement;

    private float _horizontalAimDir;
    private float _verticalAimDir;
    private Vector3 _aimPosition;

    void Start()
    {
        base.Initialize("Player", 100, 5f);
    }

    void Update()
    {
        // Moves player using left joystick
        _horizontalMove = _movementJoystick.Horizontal * _speed * Time.deltaTime;
        _verticalMove = _movementJoystick.Vertical * _speed * Time.deltaTime;
        _movement = new Vector3(_horizontalMove, _verticalMove, 0);
       
        transform.Translate(_movement, Space.World);

        // Rotates player using right joystick
        _horizontalAimDir = _aimingJoystick.Horizontal * Time.deltaTime;
        _verticalAimDir = _aimingJoystick.Vertical * Time.deltaTime;
        _aimPosition = new Vector3(_horizontalAimDir, _verticalAimDir, 0);        

        if (_aimPosition != Vector3.zero) 
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, _aimPosition);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health _health = collision.gameObject.GetComponent<Health>();

        if (_health != null)
        {
            _health.TakeDamage(5);
        }
    }
}
