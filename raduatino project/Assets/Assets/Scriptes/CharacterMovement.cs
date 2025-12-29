using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 8f;
    public float slowBackSpeedMultiplier = 0.5f; // S basınca hız
    public float jumpForce = 8f;

    private CharacterController characterController;
    private float verticalVelocity;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float currentSpeed = speed;

        // ⬇️ S tuşuna basılıysa yavaşla
        if (verticalInput < 0)
        {
            currentSpeed *= slowBackSpeedMultiplier;
        }

        Vector3 moveDirection =
            (transform.forward * verticalInput) +
            (transform.right * horizontalInput);

        moveDirection *= currentSpeed;

        if (characterController.isGrounded)
        {
            if (verticalVelocity < 0)
                verticalVelocity = -1f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
            }
        }

        verticalVelocity += Physics.gravity.y * Time.deltaTime * 3f;
        moveDirection.y = verticalVelocity;

        characterController.Move(moveDirection * Time.deltaTime * 3f);
    }
}
