using UnityEngine;

public class GunCursor : MonoBehaviour
{
    public Transform gunFirePoint; // The position where the gun fires
    public Canvas cursorCanvas;   // The canvas holding the cursor
    public RectTransform cursorImage; // The RectTransform of the crosshair image
    public float cursorDistance = 5f; // Distance from the gun

    void Update()
    {
        UpdateCursorPosition();
    }

    void UpdateCursorPosition()
    {
        // Perform a raycast from the gun's fire point
        Ray ray = new Ray(gunFirePoint.position, gunFirePoint.forward);
        RaycastHit hit;

        Vector3 cursorPosition;
        if (Physics.Raycast(ray, out hit))
        {
            // Place the cursor at the hit point
            cursorPosition = hit.point;
        }
        else
        {
            // Place the cursor at a fixed distance
            cursorPosition = ray.GetPoint(cursorDistance);
        }

        // Update the canvas position to match the cursor
        cursorCanvas.transform.position = cursorPosition;
        cursorCanvas.transform.LookAt(Camera.main.transform); // Make it face the player

        // adjust the size of the cursor dynamically
        float distance = Vector3.Distance(gunFirePoint.position, cursorPosition);
        cursorImage.localScale = Vector3.one * (distance / cursorDistance);

    }
}
