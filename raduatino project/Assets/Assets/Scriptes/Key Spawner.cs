using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    public GameObject key;
    public Transform eliminucu;
    public bool canLoadScene = false;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Key"))
        {
            Instantiate(key,eliminucu);
            Destroy(hit.gameObject);
            canLoadScene = true;
        }
    }
}
