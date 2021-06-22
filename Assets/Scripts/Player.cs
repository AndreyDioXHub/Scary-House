using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private CharacterController _playerController;
    [SerializeField]
    private Transform _playerBody;
    [SerializeField]
    private Camera _playerCamera;
    [SerializeField]
    private float _speed = 1f;
    /*[SerializeField]
    private float _jumpHeight = 1f;*/
    [SerializeField]
    private float _mouseSensivity = 100f;
    [SerializeField]
    private float _gravity = -9.8f;
    [SerializeField]
    private float _groundDistance = 0.1f;

    private float _xRotation = 0f;
    private Vector3 _velocity;

    //private bool _isGrounded = false;


    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.CheckSphere(_playerBody.transform.position, _groundDistance))
        {
            //_isGrounded = true;
            _velocity.y = -2f;// Vector3.zero;
        }/*
        else
        {
            _isGrounded = false;
        }*/

        
        /*if (_isGrounded == true && Input.GetButtonDown("Jump"))
        {
            _velocity.y = Mathf.Sqrt(_jumpHeight *-2f* _gravity);
        }*/
        

        float mouseX = Input.GetAxis("Mouse X") * _mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensivity * Time.deltaTime;

        _xRotation -= mouseY;

        _playerCamera.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        _playerBody.Rotate(Vector3.up, mouseX);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        _playerController.Move(move*_speed);

        _velocity.y += _gravity * Time.deltaTime;
        _playerController.Move(_velocity * Time.deltaTime);
    }
}
