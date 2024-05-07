using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    public Camera playerCamera;
    float _walkSpeed = 4f;
    float _jumpPower = 6.5f;
    float _gravity = 10f;


    float _lookSpeed = 2f;
    float _lookXLimit = 90f;
    float _curSpeedX=0;
    float _curSpeedY=0;

    int _fov = 90;

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true;


    public CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Camera.main.fieldOfView = _fov;
    }

    void Update()
    {

        #region Handles Movement
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        if (characterController.isGrounded)
        {
            _curSpeedX = canMove ? _walkSpeed * Input.GetAxisRaw("Vertical") : 0;
            _curSpeedY = canMove ? _walkSpeed * Input.GetAxisRaw("Horizontal") : 0;
            moveDirection.y = 0;
        }
        else
        {
            _curSpeedX = canMove ? _walkSpeed * Input.GetAxis("Vertical") : 0;
            _curSpeedY = canMove ? _walkSpeed * Input.GetAxis("Horizontal") : 0;
            moveDirection.y -= _gravity * Time.deltaTime;
        }
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * _curSpeedX) + (right * _curSpeedY);

        #endregion

        #region Handles Jumping
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = _jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        #endregion

        #region Handles Rotation
        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * _lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -_lookXLimit, _lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * _lookSpeed, 0);
        }
        #endregion
    }
    private void FixedUpdate()
    {
        playerCamera.transform.position = transform.position;
    }
    public Vector3 GetMovement() { return moveDirection; }
}