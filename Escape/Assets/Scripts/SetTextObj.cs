using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public int objectIndex; //! The index to identify which object was clicked

    private ObjectClickHandler clickHandler;

    void Start()
    {
        //! Find the ObjectClickHandler in the scene
        clickHandler = FindObjectOfType<ObjectClickHandler>();
    }

    //! Detect when the object is clicked
    void OnMouseDown()
    {
        if (clickHandler != null)
        {
            //!Call the method to update the UI text with this object's index
            clickHandler.OnObjectPressed(objectIndex);
        }
    }
}
