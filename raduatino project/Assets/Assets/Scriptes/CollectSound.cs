using UnityEngine;

public class CollectSound : MonoBehaviour
{
    public float collectDistance = 1f;

    void Update()
    {
        RaycastHit hit;

        // Karakterin önüne kýsa bir ray at
        if (Physics.Raycast(transform.position, transform.forward, out hit, collectDistance))
        {
            if (!hit.collider.CompareTag("TriggerObject"))
                return;

            AudioSource audio = hit.collider.GetComponent<AudioSource>();
            if (audio == null)
                return;

            if (!audio.isPlaying)
            {
                audio.Play();
                Destroy(hit.collider.gameObject, audio.clip.length);
            }
        }
    }
}
