using System;
using System.Collections;
using System.Collections.Generic;
using Codice.Client.Commands.WkTree;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
/// \class OpenBag
/// \brief Responsible for the Item view, e.g which Item can be seen by the player,also offers functions to read and display text
///
/// 
public class OpenBag : MonoBehaviour
{
    //!Open Bag manages the UI for opening the player inventory
    public TextMeshProUGUI text;
    public GameObject answer;
    public GameObject inventoryUI;
    private Inventory inventory;
    public List<GameObject> allObjects;
    private Image image;
    private Material material;
    private AudioSource audioSource;
    public AudioClip clickSound;
    public GameObject EmailView;
    public GameObject CoverUP;
    void Start()
    {
        inventory = Inventory.inventory;
        inventoryUI.SetActive(false);
        audioSource = GetComponent<AudioSource>();
                if (audioSource == null)
                {
                    audioSource = gameObject.AddComponent<AudioSource>();
                }

                // Optional: Assign the audio clip if it's not assigned via the Inspector
                if (clickSound != null)
                {
                    audioSource.clip = clickSound;
                }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (!EmailView.activeSelf)
        {
            if (clickSound != null)
            {
                audioSource.PlayOneShot(clickSound);
            }

            if (text.enabled && !CoverUP.activeSelf)
            {
                //!If text is enabled, we switch to inventory view, same goes vice versa

                text.enabled = false;
                answer.SetActive(false);
                inventoryUI.SetActive(true);
                CoverUP.SetActive(false);

                UpdateGrayScale();
                return;
            }

            inventoryUI.SetActive(false);
            answer.SetActive(true);
            text.enabled = true;
        }
    }

    private void UpdateGrayScale()
    {
        //! Update through all items and look which item is contained in the player inventory, items which are not contained are displayed in a gray theme
        foreach (var VARIABLE in allObjects)
        {
            image = VARIABLE.GetComponent<Image>();
            material = new Material(image.material);
            image.material = material;
            AllItems current = (AllItems)Enum.Parse(typeof(AllItems),VARIABLE.gameObject.name);
            if (inventory.contains(current))
            {
                image.material.SetFloat("_GrayscaleAmount",0 );
                continue;
            }
            image.material.SetFloat("_GrayscaleAmount",1);

        }
    }
}