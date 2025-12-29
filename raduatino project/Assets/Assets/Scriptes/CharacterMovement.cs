using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 8f;
    public float slowBackSpeedMultiplier = 0.5f;
    public float jumpForce = 8f;

    public float normalGravityMultiplier = 2.5f;
    public float slowGravityMultiplier = 0.5f;

    private CharacterController characterController;
    private float verticalVelocity;

    private bool isSlowed = false; // KALICI

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float currentSpeed = speed;

        if (verticalInput < 0)
            currentSpeed *= slowBackSpeedMultiplier;

        Vector3 moveDirection =
            (transform.forward * verticalInput) +
            (transform.right * horizontalInput);

        moveDirection *= currentSpeed;

        if (characterController.isGrounded)
        {
            if (verticalVelocity < 0)
                verticalVelocity = -2f;

            if (Input.GetKeyDown(KeyCode.Space))
                verticalVelocity = jumpForce;
        }

        // ⬇️ KALICI GRAVITY
        float gravityMultiplier = isSlowed
            ? slowGravityMultiplier
            : normalGravityMultiplier;

        verticalVelocity += Physics.gravity.y * gravityMultiplier * Time.deltaTime * 1.5f;

        moveDirection.y = verticalVelocity;
        characterController.Move(moveDirection * Time.deltaTime * 1.5f);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // BİR KERE değmesi yeterli
        if (hit.collider.CompareTag("Slow"))
        {
            isSlowed = true;
        }
    }
}
