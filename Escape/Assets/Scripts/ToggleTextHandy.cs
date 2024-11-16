using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// \class ToggleTextHandy
/// \brief Manages the toggling of UI elements for text and answers.
///
/// The `ToggleTextHandy` class is designed to control the visibility of two UI canvases (`TextCanvas` and `AnswerCanvas`) based on user interactions. It responds to mouse clicks on the GameObject it is attached to, toggling the active state of these canvases and their parent objects.
///
/// \details
/// This script is particularly useful for managing UI interactions in scenarios where multiple canvases need to be shown or hidden dynamically. It ensures that the correct parent objects are activated or deactivated to maintain the intended UI flow.
///
/// \author [Your Name]
public class ToggleTextHandy : MonoBehaviour
{
    /// \brief Reference to the canvas that displays text.
    public GameObject TextCanvas;

    /// \brief Reference to the canvas that displays answer options.
    public GameObject AnswerCanvas;

    /// \brief Disables both `TextCanvas` and `AnswerCanvas`.
    ///
    /// \details
    /// This method sets the `activeSelf` state of both canvases to `false`, effectively hiding them from the user.
    void DisableTextObjects()
    {
        TextCanvas.gameObject.SetActive(false);
        AnswerCanvas.gameObject.SetActive(false);
    }

    /// \brief Enables both `TextCanvas` and `AnswerCanvas`.
    ///
    /// \details
    /// This method sets the `activeSelf` state of both canvases to `true`, making them visible to the user.
    void EnableTextObjects()
    {
        TextCanvas.gameObject.SetActive(true);
        AnswerCanvas.gameObject.SetActive(true);
    }

    /// \brief Handles mouse click interactions on the attached GameObject.
    ///
    /// \details
    /// This method toggles the visibility of the `TextCanvas` and `AnswerCanvas` based on their current state. It also manipulates the active state of parent GameObjects to ensure proper UI interaction.
    /// 
    /// - If the `AnswerCanvas` is active, it disables both canvases and activates the parent GameObject two levels above the current object in the hierarchy.
    /// - If the `AnswerCanvas` is inactive, it enables both canvases and deactivates the parent GameObject two levels above the current object in the hierarchy.
    ///
    /// \note This method relies on the Unity event system and requires the GameObject to have a collider for `OnMouseDown` to work.
    private void OnMouseDown()
    {
    

        //! Check if the `AnswerCanvas` is active.
        if (AnswerCanvas.gameObject.activeSelf)
        {
            
            DisableTextObjects();

            //! Activate the grandparent GameObject.
            gameObject.transform.parent.gameObject.transform.parent.gameObject.SetActive(true);
            return;
        }

        //! Check if the `AnswerCanvas` is inactive.
        if (!AnswerCanvas.gameObject.activeSelf)
        {

            //! Deactivate the grandparent GameObject.
            gameObject.transform.parent.gameObject.transform.parent.gameObject.SetActive(false);

            EnableTextObjects();
        }
    }
}
