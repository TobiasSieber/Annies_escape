using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestDialogueFiles : MonoBehaviour
{

    void Start()
    {
        StartConversation();
    }



    void StartConversation()
    {
        List<string> lines = FileManager.ReadTextAsset("testFile");

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
                return;
            Debug.Log($"Segmenting line '{line}'");
            Dialogue_Line dline = DialogueParser.Parse(line);
            foreach (DL_Dialogue_DATA.Dialogue_SEGMENT segment in dline.dialogue.segments)
            {
                Debug.Log(segment.startSignal.ToString());
                 Debug.Log($"Segment ='{segment.dialogue}' [Singal={segment.startSignal.ToString()}{(segment.signalDelay > 0 ? $" {segment.signalDelay}" : $"")}");

            }
            {
                
            }

        }
        DialogueSystem.instance.Say(lines);

    }
}
