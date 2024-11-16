using TMPro;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

/// \class EventExectuer
/// \brief Manages event-based actions and object activations based on event IDs.
public class EventExectuer : MonoBehaviour
{
    //! UI object for displaying notifications.
    public TextMeshProUGUI notificationObject;

    //! GameObject representing the left side picture display.
    public GameObject leftpicture;

    //! GameObject representing the death state, previously serialized as "Death".
    [FormerlySerializedAs("Death")] public GameObject death;

    //! Sprite to display upon death.
    public Sprite deathImage;

    private  storage storage = storage.Storage;
    private  Inventory Inventory = Inventory.inventory;
    //! List of GameObjects to activate based on event decisions.
    public List<GameObject> objectsToActivate;

    public ClickDecision clickDecision;
    //! Name of the scene to load when a death event is triggered.
    public string deathSceneName = "DeathScene01";

    //! Activates specific objects based on the provided decision ID.
    /*!
        \param decisionID The ID used to determine which object to activate.
    */
    public void ActivateObjectBasedOnID(int decisionID)
    {
        // Deactivate all objects initially.
        ActivateObject(decisionID);
    }

    //! Activates a specific object based on index range checks.
    /*!
        \param index The index value used to activate specific objects within the list.
    */
    private void ActivateObject(int index)
    {
        if (index <= 4)
        {
            objectsToActivate[0].SetActive(true);
        }
        else if (index >= 45 && index < 48)
        {
            objectsToActivate[1].SetActive(true);
        }
        else if (index >= 65 && index <= 68)
        {
            objectsToActivate[2].SetActive(true);
        }
        else
        {
            Debug.LogWarning("Index out of range: " + index);
        }
    }

    //! Triggers an event based on the specified event handler.
    /*!
        \param eventHandler The EventHandler object used to determine the event type and ID.
    */
    public void TriggerEvent(EventHandler eventHandler)
    {
        int eventId = eventHandler.GetId; // Assumes GetId returns the start ID or similar value
        ActivateObjectBasedOnID(eventId);
        Debug.Log("EVENTID JETT");
        Debug.Log(eventId);

        switch (eventHandler.GetType)
        {
            case EventEnum.backgroundpicture:
                Debug.Log("Changing background now");

                // Use the PictureLoader script to update the background based on event ID.
                PictureLoader pictureLoader = leftpicture.GetComponent<PictureLoader>();
                if (pictureLoader != null)
                {
                    pictureLoader.UpdatePictureBasedOnRange(eventId);
                }
                else
                {
                    Debug.LogError("PictureLoader component not found on leftpicture.");
                }
                break;

            case EventEnum.inventory:
                Debug.Log("Inventory event");
                break;

            case EventEnum.Death:
                clickDecision.ResetRoundExtern();
                storage.DropStorage();
                Inventory.DropInventory();
                SceneManager.LoadScene(deathSceneName);
                
                break;

            case EventEnum.EmailOpen:
                // Handle EmailOpen event if necessary.
                break;

            default:
                Debug.LogWarning("Unhandled event type: " + eventHandler.GetType);
                break;
        }
    }
}
