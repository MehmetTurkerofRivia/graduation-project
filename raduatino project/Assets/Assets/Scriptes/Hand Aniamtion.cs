using UnityEngine;

public class HandAniamtion : MonoBehaviour
{
    [SerializeField] private float pitchSpeed = 2f;    // Mouse hassasiyeti
    [SerializeField] private float minPitch = -60f;    // En aþaðý açý
    [SerializeField] private float maxPitch = 60f;     // En yukarý açý

    private float currentPitch = 0f;

    void Update()
    {
        // Mouse dikey hareketini al
        float mouseY = Input.GetAxis("Mouse Y");

        // Pitch açýsýný güncelle
        currentPitch -= mouseY * pitchSpeed;
        currentPitch = Mathf.Clamp(currentPitch, minPitch, maxPitch);

        // Sadece X ekseninde (yukarý-aþaðý) döndür
        Vector3 localEuler = transform.localEulerAngles;
        localEuler.x = currentPitch;
        transform.localEulerAngles = localEuler;
    }
}