using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class ColorWheel : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public Material targetMaterial;   // The material whose color we change
    private RawImage rawImage;
    private Texture2D wheelTexture;

    private void Awake()
    {
        rawImage = GetComponent<RawImage>();

        // Try to get Texture2D from RawImage texture (make sure it's readable)
        wheelTexture = rawImage.texture as Texture2D;

        if (wheelTexture == null)
            Debug.LogError("ColorWheel requires a readable Texture2D assigned to RawImage.");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        UpdateColor(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        UpdateColor(eventData);
    }

    private void UpdateColor(PointerEventData eventData)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rawImage.rectTransform, 
            eventData.position, 
            eventData.pressEventCamera, 
            out localPoint);

        Rect rect = rawImage.rectTransform.rect;

        // Normalize local point (0 to 1)
        float px = (localPoint.x - rect.x) / rect.width;
        float py = (localPoint.y - rect.y) / rect.height;

        if (px < 0 || px > 1 || py < 0 || py > 1)
            return; // outside the wheel

        if (wheelTexture == null)
            return;

        // Get pixel color from texture
        Color pickedColor = wheelTexture.GetPixelBilinear(px, py);

        // Apply to material
        if (targetMaterial != null)
        {
            targetMaterial.color = pickedColor;
        }
    }
}
