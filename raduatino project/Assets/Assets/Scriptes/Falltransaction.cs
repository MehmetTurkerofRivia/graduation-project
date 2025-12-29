using UnityEngine;
using UnityEngine.SceneManagement;

public class Falltransaction : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Door"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
