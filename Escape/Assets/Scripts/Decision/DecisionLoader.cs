using System.Collections;
using UnityEngine;
using TMPro;
/// \class DecisionLoader
/// \brief Acts as a bridge between user inputs and scenes, e.g changing of texts. 
public class DecisionLoader : MonoBehaviour
{
    //! Singleton references for decision and text receivers
    private readonly reciever reciever = reciever.Reciever;
    private readonly TextReciever textReciever = TextReciever.textReciever;

    //! UI references for answer text fields and main text display
    public TextMeshProUGUI ans1;
    public TextMeshProUGUI ans2;
    public TextMeshProUGUI ans3;
    public TextMeshProUGUI ans4;
    public TextMeshProUGUI Text;

    //! Additional component references
    public ScrollRectHelp scrollRectHelp;
    public PictureLoader pictureLoader;
    public GameObject pictureObject;

    //! Control variables for typing and cooldown behavior
    private bool skipTyping = false;
    private float defaultDelay = 0.1f; // Default delay for text typing
    private uint parseDecisionID = 0;
    private bool triggerOut = false;
    private uint index;
    public float cooldownTime = 2f; // Time before skipping is re-enabled
    private bool canSkip = true; // Flag to enable/disable skipping
    private float cooldownTimer = 0f;
    private bool complete;
    private AudioSource audioSource;

    private void Start()
    {
        //! Initialize audio source and load initial text
        audioSource = GetComponent<AudioSource>();
        LoadTextintoObject(1);
    }

    private void Update()
    {
        //! Handle skipping when space is pressed and cooldown allows it
        if (Input.GetKeyDown(KeyCode.Space) && canSkip)
        {
            skipTyping = true;
            Debug.Log("SKIPPING");
            StartCooldown();
        }

        //! Cooldown countdown to re-enable skipping
        if (!canSkip)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0)
            {
                canSkip = true;
            }
        }
    }

    //! Sets cooldown for skipping functionality
    private void StartCooldown()
    {
        cooldownTimer = cooldownTime;
        canSkip = false;
    }

    //! Loads decision descriptions into answer text fields
    private void LoadintoObjects(uint start)
    {
        ans1.text = reciever.GetDecision(start).GetdecisionDescription();
        ans2.text = reciever.GetDecision(start + 1).GetdecisionDescription();
        ans3.text = reciever.GetDecision(start + 2).GetdecisionDescription();
        ans4.text = reciever.GetDecision(start + 3).GetdecisionDescription();
        index = start;
    }

    //! Initiates typing coroutine and plays audio
    public void LoadTextintoObject(uint to_call)
    {
        StartCoroutine(TypeTextAndLoad(to_call));
        audioSource.Play();
    }

    //! Coroutine to handle typing effect with picture display
    IEnumerator TypeTextAndLoad(uint to_call)
    {
        //! Show picture at start of typing
        pictureObject.SetActive(true);

        //! Start typing the text with a delay
        yield return StartCoroutine(TypeText(textReciever.GetTText(to_call).GetdecisionDescription(), 0.03f, to_call));

        //! Load decision descriptions into answer objects after typing completes
        uint start = to_call * 4 - 3;
        LoadintoObjects(start);

        //! Hide picture after typing is complete
        pictureObject.SetActive(false);
    }

    //! Setters for decision parser and trigger out flag
    public void setParser(uint parseDecisionID)
    {
        this.parseDecisionID = parseDecisionID;
    }


    public void setTriggerOut(bool TriggerOut)
    {
        this.triggerOut = TriggerOut;
    }

    //! Coroutine to type out text character by character
    IEnumerator TypeText(string text, float delay, uint to_call)
    {
        complete = false; // Reset completion status

        //! If a specific decision is set, add aligned and colored text
        if (parseDecisionID > 0)
        {
            Text.text += "<align=right><color=yellow>";
            foreach (char letter in reciever.GetDecision(parseDecisionID).GetdecisionDescription())
            {
                Text.text += letter;

                //! Add new line in scroll if current line is complete
                if (IsLineCompleted())
                    scrollRectHelp.AddNewLine();

                //! Handle skip typing functionality
                if (skipTyping)
                {
                    Text.text += text;
                    skipTyping = false;
                    break;
                }

                yield return new WaitForSeconds(delay);
            }
            Text.text += "\n";

            //! Continue with follow-up text after main text is complete
            foreach (char letter in reciever.GetDecision(parseDecisionID).GetFollowText())
            {
                Text.text += letter;
                if (IsLineCompleted())
                    scrollRectHelp.AddNewLine();

                yield return new WaitForSeconds(delay);
            }
        }

        //! Complete audio and formatting adjustments
        audioSource.Stop();
        yield return new WaitForSeconds(1f);
        audioSource.Play();
        Text.text += "</color=white></align=left>\n\n";

        //! Type the main text content
        bool lastCharDisplayed = false; // Flag to track last character
        foreach (char letter in text)
        {
            Text.text += letter;

            //! Set flag when last character is displayed
            lastCharDisplayed = (letter == text[text.Length - 1]);

            if (IsLineCompleted())
                scrollRectHelp.AddNewLine();

            //! Handle skip typing functionality
            if (skipTyping)
            {
                Text.text += text;
                skipTyping = false;
                lastCharDisplayed = true;
                break;
            }

            yield return new WaitForSeconds(delay);
        }

        //! Finalize typing
        Text.text += "\n\n";

        if (lastCharDisplayed)
        {
            audioSource.Stop();
            complete = true; // Mark as complete when typing ends
        }
    }

    //! Track if line is completed by checking height increase
    private float previousHeight = 0f;
    private bool IsLineCompleted()
    {
        float currentHeight = Text.preferredHeight;
        bool lineCompleted = currentHeight > previousHeight;
        previousHeight = currentHeight;

        return lineCompleted;
    }

    //! Event handler for when the first answer is clicked
    public void OnAnswer1Clicked()
    {
        Debug.Log("Hier kommt MUKKE");
    }

    //! Returns if typing is complete
    public bool GetComplete()
    {
        return complete;
    }
}
