using UnityEngine;
using UnityEngine.UI; // For UI Text
using TMPro; // For TextMeshPro

public class DisplayTextOnImage : MonoBehaviour
{
    // Reference to the UI Text or TextMeshPro component
    public TextMeshProUGUI textMeshPro; // Use TextMeshProUGUI for TextMeshPro
    public Text uiText; // Use Text for standard UI text

    // Define text attributes (can be different strings)
    public string textAttribute1 = "Level Complete";
    public string textAttribute2 = "Score: 100";
    public string textAttribute3 = "Next Level in 5 seconds";

    // Choose which text attribute to display
    public int displayTextIndex = 0;

    void Start()
    {
        // Display the first text by default when the game starts
        UpdateText(displayTextIndex);
    }

    // Method to update the text dynamically
    public void UpdateText(int index)
    {
        string newText = "";

        switch(index)
        {
            case 0:
                newText = textAttribute1;
                break;
            case 1:
                newText = textAttribute2;
                break;
            case 2:
                newText = textAttribute3;
                break;
            default:
                newText = "No Text Set";
                break;
        }

        // Update either TextMeshPro or regular UI Text depending on what you're using
        if (textMeshPro != null)
            textMeshPro.text = newText;
        else if (uiText != null)
            uiText.text = newText;
    }
}
