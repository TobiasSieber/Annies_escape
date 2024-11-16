using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem  : MonoBehaviour
{
    public DialogueContainer dialogueContainer = new DialogueContainer();
    private ConversationManager conversationManager;
    private TextArchitect architect;
    public static DialogueSystem instance;

    public delegate void DialogueSystemEvent();

    public event DialogueSystemEvent onUserPrompt_Next;
    public bool isRunningConversation => conversationManager.isRunning;

    private void Awake(){
        if(instance==null){
            instance=this;
            Initialize();

        }
        else{
            DestroyImmediate(gameObject);
        }

     
    }

    bool _initialized = false;
    private void Initialize()
    {
        if (_initialized)
            return;
        architect = new TextArchitect(dialogueContainer.dialogueText);
        conversationManager = new ConversationManager(architect);

    }

    public void OnUserPromt_Next()
    {
        onUserPrompt_Next?.Invoke();
    }

    public void Say(string dialogue)
    {
        
        List<string> conversation = new List<string>() {$"{dialogue}"};
        Say(conversation);

    }

    public void Say(List<string> conversation)
    {
        
        conversationManager.StartConversation(conversation);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        // Your start logic here
    }

    // Update is called once per frame
    void Update()
    {
        // Your update logic here
    }
}
