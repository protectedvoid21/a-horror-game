using System;
using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour {
    [SerializeField] private Transform cameraTransform;
    private CharacterController characterController;

    [HideInInspector] public Vector3 moveDirection;
    private Vector3 verticalDirection;
    [SerializeField] private float startSpeed;
    [SerializeField] private float sprintModifier;

    private float speed;

    [SerializeField, Min(0)]
    private float gravityForce;

    [SerializeField] private float jumpForce;

    private float YRotation;
    private bool isGrounded;

    private void Start() {
        speed = startSpeed;
        
        Cursor.visible = false;

        characterController = GetComponent<CharacterController>();

        if(!IsLocalPlayer) {
            cameraTransform.gameObject.GetComponent<Camera>().enabled = false;
            cameraTransform.gameObject.GetComponent<AudioListener>().enabled = false;
        }
    }

    private void Update() {
        if(!IsLocalPlayer) {
            return;
        }
        
        if(Cursor.lockState != CursorLockMode.Locked) {
            return;
        }
        
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Look();

        if(Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }

        if(Input.GetKey(KeyCode.LeftShift)) {
            speed = startSpeed * sprintModifier;
        }
        else {
            speed = startSpeed;
        }

        verticalDirection.y -= gravityForce * Time.deltaTime;
        moveDirection = transform.right * x + transform.forward * z;

        characterController.Move(moveDirection.normalized * speed * Time.deltaTime);
        characterController.Move(verticalDirection * Time.deltaTime);
    }

    private void Look() {
        float mouseX = Input.GetAxis("Mouse X") * 5f;
        YRotation -= Input.GetAxis("Mouse Y") * 5f;
        YRotation = Mathf.Clamp(YRotation, -90f, 90f);

        transform.Rotate(0, mouseX, 0);
        cameraTransform.localRotation = Quaternion.Euler(YRotation, 0, 0);
    }

    private void Jump() {
        if(characterController.isGrounded == false) {
            return;
        }
        
        verticalDirection.y = Mathf.Sqrt(jumpForce);
    }
}
