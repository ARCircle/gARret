using UnityEngine;

public class fuku_dress : MonoBehaviour
{
    private int dress;

    private Animator animator;

    // Use this for initialization
    private void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("touch");

            if (dress == 0)
            {
                dress = 1;
            }
            else
            {
            }
        }
    }
}