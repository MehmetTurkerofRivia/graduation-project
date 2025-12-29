using UnityEngine;

public class PlaySoundOnSc : MonoBehaviour
using UnityEngine;

public class TagBasedSoundPlayer : MonoBehaviour
{
    [System.Serializable]
    public class TagSound
    {
        public string tag;
        public AudioClip clip;
    }

    public TagSound[] tagSounds;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlaySoundByTag(collision.gameObject.tag);
    }

    // Eðer Trigger kullanýyorsan bunu aç
    /*
    private void OnTriggerEnter(Collider other)
    {
        PlaySoundByTag(other.gameObject.tag);
    }
    */

    void PlaySoundByTag(string objectTag)
    {
        foreach (TagSound ts in tagSounds)
        {
            if (ts.tag == objectTag)
            {
                audioSource.PlayOneShot(ts.clip);
                return;
            }
        }
    }
}
