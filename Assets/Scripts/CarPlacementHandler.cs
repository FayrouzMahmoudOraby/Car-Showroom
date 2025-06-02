using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;
using System.Collections.Generic;

public class CarPlacementHandler : MonoBehaviour
{
    public ARPlacementInteractable placementInteractable;
    public List<GameObject> carPrefabs;

    private GameObject currentCarInstance;
    private bool hasPlacedCar = false;
    private Transform placementAnchor;

    private void OnEnable()
    {
        placementInteractable.objectPlaced.AddListener(OnObjectPlaced);
    }

    private void OnDisable()
    {
        placementInteractable.objectPlaced.RemoveListener(OnObjectPlaced);
    }

    private void OnObjectPlaced(ARObjectPlacementEventArgs args)
    {
        if (hasPlacedCar) return;

        placementAnchor = args.placementObject.transform;
        currentCarInstance = Instantiate(carPrefabs[0], placementAnchor);
        hasPlacedCar = true;

        placementInteractable.enabled = false;
    }

    public void ChangeCarModelToSecondCar()
    {
        if (!hasPlacedCar || carPrefabs == null || carPrefabs.Count <= 1)
        {
            Debug.LogWarning("Cannot switch to second car. Either car not placed or index 1 is invalid.");
            return;
        }

        if (currentCarInstance != null)
        {
            Destroy(currentCarInstance);
        }

        currentCarInstance = Instantiate(carPrefabs[1], placementAnchor);
    }

    public void ChangeCarModelToFirstCar()
    {
        if (!hasPlacedCar || carPrefabs == null || carPrefabs.Count <= 1)
        {
            Debug.LogWarning("Cannot switch to second car. Either car not placed or index 1 is invalid.");
            return;
        }

        if (currentCarInstance != null)
        {
            Destroy(currentCarInstance);
        }

        currentCarInstance = Instantiate(carPrefabs[0], placementAnchor);
    }

}
