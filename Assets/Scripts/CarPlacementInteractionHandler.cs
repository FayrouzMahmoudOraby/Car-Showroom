using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class CarPlacementInteractionHandler : MonoBehaviour
{
    public ARPlacementInteractable placementHandler;
    public Button rotateCarButton;

    private bool isCarPlaced = false;

    private void OnEnable()
    {
        placementHandler.objectPlaced.AddListener(HandleCarPlacement);
    }

    private void OnDisable()
    {
        placementHandler.objectPlaced.RemoveListener(HandleCarPlacement);
    }

    private void HandleCarPlacement(ARObjectPlacementEventArgs args)
    {
        if (isCarPlaced) return;

        GameObject carObject = args.placementObject.gameObject;
        CarRotationController rotator = carObject.GetComponent<CarRotationController>();

        if (rotator != null)
        {
            rotateCarButton.onClick.AddListener(rotator.ToggleCarRotation);
            isCarPlaced = true;
        }
    }
}
