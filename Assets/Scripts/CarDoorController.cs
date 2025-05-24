using UnityEngine;

public class CarDoorController : MonoBehaviour
{
    public GameObject leftDoorObject;
    public GameObject rightDoorObject;

    private Animator leftDoorAnimator;
    private Animator rightDoorAnimator;

    private bool isLeftDoorOpen = false;
    private bool isRightDoorOpen = false;

    void Start()
    {
        if (leftDoorObject != null)
            leftDoorAnimator = leftDoorObject.GetComponent<Animator>();

        if (rightDoorObject != null)
            rightDoorAnimator = rightDoorObject.GetComponent<Animator>();
    }

    public void ToggleLeftDoor()
    {
        if (leftDoorAnimator != null)
        {
            isLeftDoorOpen = !isLeftDoorOpen;
            leftDoorAnimator.SetBool("Open", isLeftDoorOpen);
        }
    }

    public void ToggleRightDoor()
    {
        if (rightDoorAnimator != null)
        {
            isRightDoorOpen = !isRightDoorOpen;
            rightDoorAnimator.SetBool("Open", isRightDoorOpen);
        }
    }

   
}
