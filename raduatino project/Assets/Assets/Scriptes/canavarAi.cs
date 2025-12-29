using UnityEngine;

public class canavarAi : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    public Camera playerCamera;
    public Animator animator;

    [Header("Movement")]
    public float maxSpeed = 3.5f;   // uzaktaki hız
    public float minSpeed = 1.2f;   // yakındaki hız
    public float rotationSpeed = 8f;

    public float stopDistance = 2.5f;
    public float lookStopDistance = 6f;

    [Header("Freeze When Looked At")]
    public float lookAngle = 0.7f;
    public float freezeDistance = 10f;

    [Header("Animation Speed")]
    public float farAnimSpeed = 1.2f;
    public float nearAnimSpeed = 0.7f;

    void Update()
    {
        if (!player || !playerCamera || !animator) return;

        Vector3 monsterPos = transform.position;
        Vector3 playerPos = player.position;
        playerPos.y = monsterPos.y;

        float distance = Vector3.Distance(monsterPos, playerPos);

        // 👁️ Bakıyor mu?
        Vector3 toMonster = (monsterPos - player.position).normalized;
        float lookDot = Vector3.Dot(playerCamera.transform.forward, toMonster);

        bool isLooking = lookDot > lookAngle;
        bool inFreezeRange = distance <= freezeDistance;

        // DONMA
        if (isLooking && inFreezeRange)
        {
            animator.speed = 0f;
            animator.SetBool("isWalking", false);
            return;
        }

        // Animasyon hızı (mesafeye bağlı)
        animator.speed = Mathf.Lerp(
            nearAnimSpeed,
            farAnimSpeed,
            distance / freezeDistance
        );

        float currentStopDistance = isLooking ? lookStopDistance : stopDistance;

        if (distance > currentStopDistance)
        {
            // 🚶 HIZ HESABI (yaklaştıkça yavaşlar)
            float t = Mathf.InverseLerp(currentStopDistance, freezeDistance, distance);
            float moveSpeed = Mathf.Lerp(minSpeed, maxSpeed, t);

            Vector3 direction = (playerPos - monsterPos).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;

            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                lookRotation,
                rotationSpeed * Time.deltaTime
            );

            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
}