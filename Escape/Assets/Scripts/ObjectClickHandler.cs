using UnityEngine;
using UnityEngine.UI; // For UI Text
using TMPro;         // For TextMeshPro

/// \class ObjectClickHandler
/// \brief Handles click interactions on objects and updates a UI text display accordingly.
///
/// The `ObjectClickHandler` class allows objects in the game to trigger changes in a UI text display
/// (using either TextMeshProUGUI or standard UI Text) when clicked. Each object is associated with a specific
/// index that determines the text to display.
///
/// \details
/// The class maintains an array of strings (`texts`) that correspond to the text content for each clickable object.
/// When an object is clicked, the text at the specified index is displayed in the assigned text component.
///
/// 
public class ObjectClickHandler : MonoBehaviour
{
    /// \brief Reference to the TextMeshProUGUI component for displaying text.
    ///
    /// Use this if you're utilizing TextMeshPro for your UI text. This is optional and can be null
    /// if using the standard UI Text instead.
    public TextMeshProUGUI textMeshPro;

    /// \brief Reference to the standard UI Text component for displaying text.
    ///
    /// Use this if you're utilizing Unity's standard `Text` component for your UI. This is optional
    /// and can be null if using TextMeshPro instead.
    public Text uiText;

    /// \brief Array of strings to display when objects are clicked.
    ///
    /// Each index in the array corresponds to a specific object. When an object is clicked, the
    /// associated text will be displayed in the text component.
    public string[] texts;

    /// \brief Updates the UI text display when an object is clicked.
    ///
    /// \details
    /// This function is triggered when an object is clicked. It takes an index to determine which text
    /// from the `texts` array should be displayed. The method updates the `TextMeshProUGUI` or
    /// standard `UI Text` component based on the provided index.
    ///
    /// \param objectIndex The index of the object that was clicked.
    public void OnObjectPressed(int objectIndex)
    {
        // Check if the index is valid.
        if (objectIndex >= 0 && objectIndex < texts.Length)
        {
            string newText = texts[objectIndex];

            // Update the UI Text or TextMeshPro component.
            if (textMeshPro != null)
                textMeshPro.text = newText;
            else if (uiText != null)
                uiText.text = newText;
        }
        else
        {
            // Log a warning if the index is out of bounds.
            Debug.LogWarning("Invalid object index");
        }
    }
}
