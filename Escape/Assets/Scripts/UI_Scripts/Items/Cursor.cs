using UnityEngine;
using System.Collections;
///  \class Cursorbehav
///   \brief Offers logic for creating a custom cursor,in short, a GameObject which is attached to the Desktop cursor.
/// 
public class CursorBehav : MonoBehaviour
{
    public Camera cam;
    public LineRenderer lineRenderer;  // LineRenderer to draw the red line
    private float lineFadeTime = 1f;   // Time after which the line fades
    private float fadeSpeed = 1f;      // Speed of the fade
    private Color initialLineColor;    // Initial color of the line

    void Start()
    {
        // Set Cursor to not be visible
        Cursor.visible = false;

        // Get the initial color of the line
        if (lineRenderer != null)
        {
            initialLineColor = lineRenderer.startColor;
        }
    }

    void Update()
    {
        // Ray to detect if we are over the background
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Check if raycast hits an object that is not tagged as "UI"
        if (Physics.Raycast(ray, out hit) && hit.collider.tag != "UI")
        {
            // Show the cursor if it's over the background
            Cursor.visible = true;
        }

        // Get the current mouse position in screen space
        Vector2 mousePosition = Input.mousePosition;

        // Convert the screen position to world space
        mousePosition = cam.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, -cam.transform.position.z));

        // Set the GameObject position (cursor) to the mouse position
        transform.position = mousePosition;

        // Update the LineRenderer's position
        if (lineRenderer != null)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position);
        }

        // Start fading the line after 1 second
        StartCoroutine(FadeLine());
    }

    IEnumerator FadeLine()
    {
        // If LineRenderer is set and active, begin fading after the specified time
        if (lineRenderer != null)
        {
            // Initially, set the line color to red
            lineRenderer.startColor = Color.red;
            lineRenderer.endColor = Color.red;

            // Fade over time
            float elapsedTime = 0f;
            while (elapsedTime < lineFadeTime)
            {
                elapsedTime += Time.deltaTime;
                float alpha = Mathf.Lerp(1f, 0f, elapsedTime / lineFadeTime);
                lineRenderer.startColor = new Color(initialLineColor.r, initialLineColor.g, initialLineColor.b, alpha);
                lineRenderer.endColor = new Color(initialLineColor.r, initialLineColor.g, initialLineColor.b, alpha);
                yield return null;
            }
            // Ensure the line is fully transparent after fading
            lineRenderer.startColor = new Color(initialLineColor.r, initialLineColor.g, initialLineColor.b, 0);
            lineRenderer.endColor = new Color(initialLineColor.r, initialLineColor.g, initialLineColor.b, 0);
        }
    }
}
