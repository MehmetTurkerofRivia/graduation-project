using UnityEngine;

public class CharacterAniamtion : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private Animator animator;  // Inspector’dan baðlayýn
    bool isWalking = false;

    void Update()
    {
       if (Input.GetKeyDown(KeyCode.W) ||
           Input.GetKeyDown(KeyCode.A) ||
           Input.GetKeyDown(KeyCode.S) ||
           Input.GetKeyDown(KeyCode.D))
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