using System;
using System.Collections;
using System.Collections.Generic;
using Codice.Client.Commands.WkTree;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// \class OpenEmail
/// Responsible for Email view, offers logic for opening and displaying emails.
/// 
public class OpenEmail : MonoBehaviour
{
    //! Displays text related to the player's inventory or answer status.
    public TextMeshProUGUI text;

    //! The GameObject representing the answer display.
    public GameObject answer;

    //! The UI panel for the player's inventory.
    public GameObject inventoryUI;

    //! Reference to the player's inventory.
    private Inventory inventory;

    //! A list of all GameObjects in the scene that can be toggled or checked.
    public List<GameObject> allObjects;

    //! Image component for modifying grayscale effects.
    private Image image;

    //! Material used for applying grayscale effects.
    private Material material;

    //! Reference to the Decision_Loader for managing decision-based content.
    public DecisionLoader decisionLoader;

    //! Wrapper GameObject for answer elements.
    public GameObject AnswerWrapper;

    //! GameObject representing the player's bag view.
    public GameObject BagView;

    //! GameObject used to cover up UI elements.
    public GameObject CoverUP;

    //! Additional GameObject that should be disabled when toggling inventory.
    public GameObject additionalObjectToDisable;

    //! AudioSource component for playing sounds.
    private AudioSource audioSource;

    //! The audio clip that plays when clicking.
    public AudioClip clickSound;

    //! Initializes the inventory and sets up the AudioSource component.
    void Start()
    {
        inventory = Inventory.inventory;
        inventoryUI.SetActive(false);

        // Get or add AudioSource component.
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Optionally assign the audio clip.
        if (clickSound != null)
        {
            audioSource.clip = clickSound;
        }
    }

    //! Update method for frame-by-frame updates.
    void Update()
    {
        // Currently unused but kept for future updates.
    }

    //! Handles toggling inventory view and playing sound on mouse click.
    private void OnMouseDown()
    {
        if (!BagView.activeSelf)
        {
            // Play click sound if available.
            if (clickSound != null)
            {
                audioSource.PlayOneShot(clickSound);
            }

            if (text.enabled && !CoverUP.activeSelf)
            {
                //! Toggles to inventory view when text is enabled.
                text.enabled = false;
                answer.SetActive(false);
                inventoryUI.SetActive(true);
                BagView.SetActive(false);
                CoverUP.SetActive(false);

                // Disable additional GameObject if assigned.
                if (additionalObjectToDisable != null)
                {
                    additionalObjectToDisable.SetActive(false);
                }

                UpdateGrayScale();
                return;
            }

            // Reset view settings.
            inventoryUI.SetActive(false);
            answer.SetActive(true);
            text.enabled = true;

            // Optionally enable additional GameObject if needed.
            if (additionalObjectToDisable != null)
            {
                additionalObjectToDisable.SetActive(true);
            }
        }
    }

    //! Updates grayscale effect on items not contained in the player's inventory.
    private void UpdateGrayScale()
    {
        foreach (var VARIABLE in allObjects)
        {
            image = VARIABLE.GetComponent<Image>();
            material = new Material(image.material);
            image.material = material;

            //! Checks if item is in the player's inventory and sets grayscale accordingly.
            AllItems current = (AllItems)Enum.Parse(typeof(AllItems), VARIABLE.gameObject.name);
            if (inventory.contains(current))
            {
                image.material.SetFloat("_GrayscaleAmount", 0);
                continue;
            }
            image.material.SetFloat("_GrayscaleAmount", 1);
        }
    }
}
