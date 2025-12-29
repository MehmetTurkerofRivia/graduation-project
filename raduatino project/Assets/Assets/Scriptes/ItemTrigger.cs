using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    public CollectableObjects collectableObjects;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("TriggerObject"))
        {
            // LÝSTEDEN SÝL
            collectableObjects.RemoveObject(hit.gameObject);

            // OBJEYÝ KAPAT
            hit.gameObject.SetActive(false);

            // YENÝ RANDOM SEÇ
            collectableObjects.ActivateRandomObject();

            // PLAYER BÜYÜSÜN
            transform.localScale += Vector3.one * 0.09f;
        }
    }
}
