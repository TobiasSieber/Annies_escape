using System;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class ClickableObjectWithSound : MonoBehaviour
{
    private AudioSource audioSource;       //! The AudioSource component to play sounds
    public AudioClip clickSound;           //! The sound that plays when the object is clicked
    private Inventory inventory = Inventory.inventory;

    void Start()
    {
        //! Ensure the object has an AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    //! Detect mouse clicks on the object
    void OnMouseDown()
    {
        //! Check if there is a click sound assigned
        if (clickSound != null)
        {
            // Play the click sound immediately
            audioSource.PlayOneShot(clickSound);
            Debug.Log("Object clicked and sound played: " + gameObject.name);

            //! Add the item to the inventory directly
            AllItems item = (AllItems)Enum.Parse(typeof(AllItems), gameObject.name);
            inventory.AddtoInventory(item);
            Debug.Log("Item added to inventory: " + item);

            //! Start coroutine to wait until the sound finishes before hiding the object
            StartCoroutine(DeactivateAfterSound());
        }
        else
        {
            Debug.LogWarning("No click sound assigned to " + gameObject.name);
        }
    }

    //! Coroutine to deactivate the object after the sound finishes playing
    private IEnumerator DeactivateAfterSound()
    {
        //! Wait for the length of the sound clip to ensure it plays fully before the object disappears
        yield return new WaitForSeconds(clickSound.length);

        //! Deactivate the object (make it disappear)
        gameObject.SetActive(false);
    }
}
