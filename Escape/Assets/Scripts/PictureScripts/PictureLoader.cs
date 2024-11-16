using UnityEngine;
using UnityEngine.UI;

/// \class PictureLoader
/// \brief Manages picture display and clickable areas based on game events or decisions.
public class PictureLoader : MonoBehaviour
{
    //! UI Image component where the picture will be shown.
    public Image pictureDisplay;

    //! Sprites to be assigned in the Unity Inspector.
    public Sprite picture1;
    public Sprite picture2;
    public Sprite picture3;
    public Sprite picture4;
    public Sprite drawer;

    //! Clickable UI buttons for each picture.
    public GameObject clickableArea1;
    public GameObject clickableArea2;
    public GameObject clickableArea3;
    public GameObject clickableArea4;

    //! Initializes the PictureLoader by deactivating all clickable areas.
    void Start()
    {
        DeactivateAllClickableAreas();

        // Uncomment to assign OnClick listeners to buttons (assuming they have Button components).
        /*
        clickableArea1.GetComponent<Button>().onClick.AddListener(() => OnClickButton(1));
        clickableArea2.GetComponent<Button>().onClick.AddListener(() => OnClickButton(2));
        clickableArea3.GetComponent<Button>().onClick.AddListener(() => OnClickButton(3));
        clickableArea4.GetComponent<Button>().onClick.AddListener(() => OnClickButton(4));
        */
    }

    //! Handles button clicks and plays sound when an area is clicked.
    /*!
        \param buttonIndex The index of the button that was clicked.
    */
    private void OnClickButton(uint buttonIndex)
    {
        // Functionality to handle button clicks
    }

    //! Updates the picture and clickable areas based on the provided decision range.
    /*!
        \param start The starting value to determine which picture and clickable areas to activate.
    */
    public void UpdatePictureBasedOnRange(int start)
    {
        DeactivateAllClickableAreas();

        if (start >= 50 && start <= 60)
        {
            clickableArea1.SetActive(true);
            pictureDisplay.sprite = picture1;
            pictureDisplay.color = new Color(34f / 255f, 33f / 255f, 33f / 255f, 1f);
        }
        else if (start >= 61 && start <= 64)
        {
            pictureDisplay.sprite = picture1;
            pictureDisplay.color = Color.white;
        }
        else if (start == 69)
        {
            pictureDisplay.color = new Color(34f / 255f, 33f / 255f, 33f / 255f, 1f);
            clickableArea1.SetActive(true);
        }
        else if (start >= 145 && start <= 158)
        {
            pictureDisplay.sprite = drawer;
            clickableArea2.SetActive(true);
        }
        else if (start == 241)
        {
            pictureDisplay.sprite = picture1;
        }
    }

    //! Deactivates all clickable areas to reset the UI state.
    private void DeactivateAllClickableAreas()
    {
        clickableArea1.SetActive(false);
        clickableArea2.SetActive(false);
        clickableArea3.SetActive(false);
        clickableArea4.SetActive(false);
    }
}
