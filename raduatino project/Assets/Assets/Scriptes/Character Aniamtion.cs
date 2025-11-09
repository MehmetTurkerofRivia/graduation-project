using UnityEngine;

public class CharacterAniamtion : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private Animator animator;  // Inspector’dan baðlayýn
    bool isWalking = false;

    void Update()
    {
       if (Input.GetKey(KeyCode.W) ||
           Input.GetKey(KeyCode.A) ||
           Input.GetKey(KeyCode.S) ||
           Input.GetKey(KeyCode.D))
        {
            isWalking = true;
        }

        if (isWalking == true)
            animator.SetBool("Is Walking", true);

        if (Input.GetKeyUp(KeyCode.W) ||
             Input.GetKeyUp(KeyCode.A) ||
             Input.GetKeyUp(KeyCode.S) ||
             Input.GetKeyUp(KeyCode.D))
        {
            isWalking = false;
        }

        if (isWalking == false)
            animator.SetBool("Is Walking", false);

    }
}