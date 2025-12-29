using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    public CollectableObjects collectableObjects;
    private bool loaded = false;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (loaded) return; // tekrar tekrar yüklemesin

        // Önce objeler bitmiş mi kontrol et
        if (!collectableObjects.canLoadScene) return;

        // Kapıya çarptı mı?
        if (hit.gameObject.CompareTag("Door"))
        {
            loaded = true;
            SceneManager.LoadScene(1);
        }
    }
}