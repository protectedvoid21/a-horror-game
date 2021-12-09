using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {
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

    private void Awake() {
        characterController = GetComponent<CharacterController>();
    }

    private void Start() {
        speed = startSpeed;
        
        Cursor.visible = false;
    }

    private void Update() {
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
