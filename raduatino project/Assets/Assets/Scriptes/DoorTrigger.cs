using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Animator doorAnimator;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Door"))
        {
            doorAnimator.SetTrigger("Open");
        }
    }
}