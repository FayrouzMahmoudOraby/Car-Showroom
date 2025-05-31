using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(ARSelectionInteractable))]
public class MenuToggleOnSelection : MonoBehaviour
{
    public GameObject menuObject;

    private ARSelectionInteractable selectionInteractable;

    private void Awake()
    {
        selectionInteractable = GetComponent<ARSelectionInteractable>();

        if (menuObject != null)
            menuObject.SetActive(false);
    }

    private void OnEnable()
    {
        selectionInteractable.selectEntered.AddListener(OnSelected);
        selectionInteractable.selectExited.AddListener(OnDeselected);
    }

    private void OnDisable()
    {
        selectionInteractable.selectEntered.RemoveListener(OnSelected);
        selectionInteractable.selectExited.RemoveListener(OnDeselected);
    }

    private void OnSelected(SelectEnterEventArgs args)
    {
        if (menuObject != null)
            menuObject.SetActive(true);
    }

    private void OnDeselected(SelectExitEventArgs args)
    {
        if (menuObject != null)
            menuObject.SetActive(false);
    }
}
