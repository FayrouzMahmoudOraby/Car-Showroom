using UnityEngine;

public class ColorWheelToggle : MonoBehaviour
{
    public GameObject colorWheelPanel;
    public void Awake()
    {
        if (colorWheelPanel != null)
            colorWheelPanel.SetActive(false);

    }

    public void ShowColorWheel()
    {
        if (colorWheelPanel != null)
            colorWheelPanel.SetActive(true);
    }

    public void HideColorWheel()
    {
        if (colorWheelPanel != null)
            colorWheelPanel.SetActive(false);
    }

    public void ToggleColorWheel()
    {
        if (colorWheelPanel != null)
            colorWheelPanel.SetActive(!colorWheelPanel.activeSelf);
    }
}
