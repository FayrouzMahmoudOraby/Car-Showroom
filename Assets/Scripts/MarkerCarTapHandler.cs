using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class MarkerCarTapHandler : MonoBehaviour
{
    public GameObject uiPanel; 

    void Awake()
    {
        var selectable = GetComponent<ARSelectionInteractable>();
        if (selectable != null)
        {
            selectable.selectEntered.AddListener(_ =>
            {
                if (uiPanel != null)
                    uiPanel.SetActive(true); 
            });
        }
    }
}

