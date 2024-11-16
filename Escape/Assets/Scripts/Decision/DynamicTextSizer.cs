using UnityEngine;
using TMPro;

/// \class DynamicTextSizer
/// \brief Dynamically resizes text and its associated collider to fit within bounds, and adjusts on collisions.
///
/// This class ensures that a `TextMeshProUGUI` component's text fits within a specified 2D box collider,
/// resizing the font size dynamically as needed. It also provides collision handling to adjust font size
/// during runtime.
///
/// \details 
/// The `DynamicTextSizer` component continuously monitors the size of the text and ensures it fits within
/// the bounds of a `BoxCollider2D`. Additionally, when a collision is detected, the font size decreases
/// slightly, and the collider is updated accordingly.
///
/// \note This component requires the GameObject to have both a `TextMeshProUGUI` and `BoxCollider2D` component.
///
/// 
[RequireComponent(typeof(TextMeshProUGUI))]
[RequireComponent(typeof(BoxCollider2D))]
public class DynamicTextSizer : MonoBehaviour
{
    /// \brief The TextMeshProUGUI component displaying the text.
    private TextMeshProUGUI textObject;

    /// \brief The BoxCollider2D used to define the bounds for the text.
    private BoxCollider2D boxCollider;

    /// \brief The maximum font size the text can have.
    public float maxFontSize = 100f;

    /// \brief The minimum font size the text can have.
    public float minFontSize = 10f;

    /// \brief The step by which the font size is adjusted during resizing.
    public float fontResizeStep = 1f;

    /// \brief Called on the script initialization.
    ///
    /// Initializes the required components (`TextMeshProUGUI` and `BoxCollider2D`) and performs an
    /// initial resize of the text and its collider.
    void Start()
    {
        //! Get the TextMeshProUGUI component.
        textObject = GetComponent<TextMeshProUGUI>();

        //! Get the BoxCollider2D component.
        boxCollider = GetComponent<BoxCollider2D>();

        //! Perform the initial resize of the text and collider.
        ResizeTextAndCollider();
    }

    /// \brief Called once per frame to ensure text and collider are resized dynamically.
    ///
    /// Continuously adjusts the font size and the collider dimensions to match the text's size.
    void Update()
    {
        ResizeTextAndCollider();
    }

    /// \brief Adjusts the text's font size to fit within the bounds of the BoxCollider2D.
    ///
    /// \details
    /// This method reduces the font size of the `TextMeshProUGUI` text until it fits within
    /// the dimensions of the `BoxCollider2D`. If the text already fits, no adjustments are made.
    void ResizeTextAndCollider()
    {
        float fontSize = maxFontSize;

        //! Continuously reduce the font size until the text fits within the collider bounds.
        while (textObject.preferredWidth > boxCollider.size.x ||
               textObject.preferredHeight > boxCollider.size.y)
        {
            fontSize -= fontResizeStep;

            //! Ensure font size does not drop below the minimum allowed size.
            if (fontSize < minFontSize)
            {
                break;
            }

            textObject.fontSize = fontSize;
        }

        //! Update the BoxCollider2D size to match the resized text dimensions.
        Vector2 newSize = new Vector2(textObject.preferredWidth, textObject.preferredHeight);
        boxCollider.size = newSize;
    }

    /// \brief Handles collision events and adjusts the text size dynamically.
    ///
    /// \details
    /// When a collision is detected, the text size is reduced by `fontResizeStep`, and the collider
    /// size is updated accordingly to maintain proper alignment with the resized text.
    ///
    /// \param collision The collision information from the `Collision2D` object.
    void OnCollisionEnter2D(Collision2D collision)
    {
        //! Decrease the font size upon collision.
        textObject.fontSize -= fontResizeStep;

        //! Recalculate the text and collider sizes after the font size change.
        ResizeTextAndCollider();
    }
}
