using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public ParticleSystem bloodEffect;
    public Transform bloodPlace;

    [Header("Fall Settings")]
    public float fallSpeed = 1.5f;
    public float rotateSpeed = 80f;

    private bool isDead = false;
    private CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    public void Die()
    {
        if (isDead) return;
        isDead = true;
        if (bloodEffect != null && bloodPlace != null)
        {
            Instantiate(
                bloodEffect,
                bloodPlace.position,
                bloodPlace.rotation
            );
        }
        if (cc != null)
            cc.enabled = false;

        StartCoroutine(FallAndRestart());
    }

    IEnumerator FallAndRestart()
    {
        float timer = 0f;
        Vector3 startPos = transform.position;
        Quaternion startRot = transform.rotation;

        Quaternion targetRotation = Quaternion.Euler(
            transform.eulerAngles.x,
            transform.eulerAngles.y,
            90f // yana yatma
        );

        while (timer < 1f)
        {
            timer += Time.deltaTime * fallSpeed;

            // Yavaşça yere doğru in
            transform.position = Vector3.Lerp(
                startPos,
                startPos + Vector3.down * 0.8f,
                timer
            );

            // Yan yatma
            transform.rotation = Quaternion.Slerp(
                startRot,
                targetRotation,
                timer
            );

            yield return null;
        }

        yield return new WaitForSeconds(0.3f);

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}
