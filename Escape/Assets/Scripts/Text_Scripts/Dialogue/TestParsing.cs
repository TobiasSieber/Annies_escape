using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class TestParsing : MonoBehaviour
{
    [SerializeField] private TextAsset file;
    // Start is called before the first frame update
    void Start()
    {
        
        sendFiletoParse();
    }

    // Update is called once per frame
    void sendFiletoParse()
    {
        List<string> lines = FileManager.ReadTextAsset("testFile");
        foreach (string line in lines)
        {
            if (line == string.Empty)
            {
                continue;
            }
            Dialogue_Line dl = DialogueParser.Parse(line);

        }
        
    }
    
}
