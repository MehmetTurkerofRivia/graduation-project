using UnityEngine;
using UnityEngine.InputSystem;
public class CharacterMovement : MonoBehaviour
{
    public float speed = 100.0f;
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Karakterin yönüne göre ileri-geri ve saða-sola hareket et
        Vector3 moveDirection = (transform.forward * verticalInput) + (transform.right * horizontalInput);
        moveDirection *= speed;

        characterController.SimpleMove(moveDirection);
    }
}