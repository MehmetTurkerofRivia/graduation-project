using UnityEngine;
public class CharacterMovement : MonoBehaviour
{
    private float walkSpeed = 1.0f;

    [SerializeField] private float mouseSensetive = 2.0f;
    [SerializeField] private float upDownRange = 80.0f;

    private CharacterController characterController;

    private float verticalRotation;

    private Camera mainCamera;

    [SerializeField] private string horizontalMoveInput = "Horizontal";
    [SerializeField] private string verticalMoveInput = "Vertical";

    [SerializeField] private string MouseXInput = "Mouse X";
    [SerializeField] private string MouseYInput = "Mouse Y";
    private void Start()
    {
        characterController = GetComponent<CharacterController>();   
        mainCamera = Camera.main;
    }

    private void Update()
    {
        HandleMovment();
        HandleRotation();
    }

    void HandleMovment()                        
    {
        float verticalSpeed = Input.GetAxis(verticalMoveInput) * walkSpeed;
        float horizontalSpeed = Input.GetAxis(horizontalMoveInput) * walkSpeed;

        Vector3 speed = new Vector3 (horizontalSpeed, 0, verticalSpeed);
        speed = transform.rotation * speed;
        characterController.Move(speed);
    }

    void HandleRotation()
    {
        float mouseXRotation = Input.GetAxis(MouseXInput) * mouseSensetive;
        transform.Rotate(0, mouseXRotation, 0);

        verticalRotation -= Input.GetAxis(MouseYInput) * mouseSensetive;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        mainCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }
}