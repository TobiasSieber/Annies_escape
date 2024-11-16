using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
/// \class ClickDecision
/// \brief Offers a functions which are responsible for handling user inputs
public class ClickDecision : MonoBehaviour
{
    //! Singleton references for storage and inventory
    private readonly storage storage = storage.Storage;
    private readonly Inventory inventory = Inventory.inventory;

    //! Reference to the decision loader and event executor
    private reciever reciever;
    public DecisionLoader decisionLoader;
    [FormerlySerializedAs("eventTrigger")] public EventExectuer eventExectuer;

    //! Control variables for decision flow
    private static uint _round = 1; // Changed to uint
    private static uint jumpto = 1; // Changed to uint
    public uint parseDescionID = 0; // Changed to uint
    public bool Trigger = false;
    private bool _canContinue = true;

    //! Audio references for click sound effects
    private AudioSource audioSource;
    public AudioClip clickSound; // Assign this in the Unity Inspector

    //! UI references for popup display when requirements are not met
    public GameObject itemRequirementPopup; // Assign this in the Unity Inspector
    public TextMeshProUGUI popupMessageText;

    private void Start()
    {
        //! Initialize the reciever instance and audio source
        reciever = reciever.Reciever;
        audioSource = GetComponent<AudioSource>();

        //! Ensure AudioSource is available
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        //! Play click sound once at the start if assigned
        if (clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }

    //! Returns the current parse decision ID
    public uint GetParseDecisionID() // Changed to uint
    {
        return parseDescionID;
    }

    //! Displays a popup if required items are missing
    private void ShowPopup()
    {
        if (itemRequirementPopup != null)
        {
            itemRequirementPopup.SetActive(true);
            popupMessageText.text = "Das kann ich nicht machen...";
            StartCoroutine(HidePopupAfterDelay(2f));
        }
    }

    //! Coroutine to hide the popup after a delay
    private IEnumerator HidePopupAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (itemRequirementPopup != null)
        {
            itemRequirementPopup.SetActive(false);
        }
    }

    //! Sets the next round based on requirements and triggers events if needed
    private void SetNextRound(uint round) // Changed to uint
    {
        AllItems required = reciever.GetDecision(round).GetRequirment();

        //! Check if inventory contains required items
        if (!inventory.contains(required))
        {
            Debug.Log("Cannot continue: Required items missing.");
            ShowPopup();
            _canContinue = false;
            return;
        }

        //! Add current decision to storage and update the jump target
        storage.AddDecision(reciever.GetDecision(round));
        jumpto = reciever.GetDecision(round).GetdecisionCall();

        //! Update inventory, parse decision ID, and trigger status
        inventory.AddtoInventory(reciever.GetDecision(round).GetReward());
        parseDescionID = reciever.GetDecision(round).GetDecisionID();
        Trigger = reciever.GetDecision(round).GetTriggerOut();

        //! Trigger event if specified
        Debug.Log(reciever.GetDecision(round).GetTriggerOut() );
        Debug.Log(reciever.EventExists(reciever.GetDecision(round)));
        if (reciever.GetDecision(round).GetTriggerOut() && reciever.EventExists(reciever.GetDecision(round)))
        {
            Debug.Log("Decision fires event...");
            eventExectuer.TriggerEvent(reciever.GetEvent(reciever.GetDecision(round).GetDecisionID()));
        }

        _canContinue = true;
    }

    //! Handles the click events for answer buttons
    private void OnMouseDown()
    {
        //! Play the click sound if assigned
        if (clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }

        //! Determine the clicked answer and set the appropriate round
        switch (gameObject.name)
        {
            case "A1":
                SetNextRound(_round);
                break;
            case "A2":
                SetNextRound(_round + 1);
                break;
            case "A3":
                SetNextRound(_round + 2);
                break;
            case "A4":
                SetNextRound(_round + 3);
                break;
        }

        //! Update decision loader and round if allowed to continue
        if (_canContinue)
        {
            _round = jumpto * 4 - 3; //! Update round based on jumpto for new decision block
            decisionLoader.setParser(parseDescionID);
            decisionLoader.LoadTextintoObject(jumpto);
            decisionLoader.setTriggerOut(Trigger);
        }
    }

    //! Sets the round externally
    public void SetRoundExtern(uint newRound) // Changed to uint
    {
        _round = newRound;
    }

    public void ResetRoundExtern()
    {
        
        _round = 1;
        jumpto = 1;
    }
}
