using UnityEngine;

public class ResetXRotation : MonoBehaviour
{
    public float duration = 1f;

    void Start()
    {
        StartCoroutine(ResetRotation());
    }

    System.Collections.IEnumerator ResetRotation()
    {
        float time = 0f;
        Quaternion startRot = transform.rotation;
        Quaternion targetRot = Quaternion.Euler(
            0f,
            transform.eulerAngles.y,
            transform.eulerAngles.z
        );

        while (time < duration)
        {
            transform.rotation = Quaternion.Lerp(startRot, targetRot, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRot;
    }
}
