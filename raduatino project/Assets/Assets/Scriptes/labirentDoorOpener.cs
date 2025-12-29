using UnityEngine;
using UnityEngine.SceneManagement;

public class labirentDoorOpener : MonoBehaviour
{
    public KeySpawner keySpawner;
    private bool loaded = false;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (loaded) return;
        if (!keySpawner.canLoadScene) return;
        if (hit.gameObject.CompareTag("Door"))
        {
            loaded = true;
            SceneManager.LoadScene(2);
        }
    }
}