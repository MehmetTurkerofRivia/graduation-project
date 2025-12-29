using UnityEngine;
using UnityEngine.SceneManagement;

public class labirentDoorOpener : MonoBehaviour
{
    public CollectableObjects collectableObjects;
    private bool loaded = false;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (loaded) return; // tekrar tekrar yüklemesin

        // Önce objeler bitmiþ mi kontrol et
        if (!collectableObjects.canLoadScene) return;

        // Kapýya çarptý mý?
        if (hit.gameObject.CompareTag("Door"))
        {
            loaded = true;
            SceneManager.LoadScene(2);
        }
    }
}