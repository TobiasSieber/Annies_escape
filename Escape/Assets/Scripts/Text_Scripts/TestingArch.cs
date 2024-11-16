using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestingArch : MonoBehaviour
{

    DialogueSystem ds;
    TextArchitect architect;
    //public GameObject target;
    int i = 0;
    string[] lines = new string[5]{
        "Wer bist du? Woher kennst du meinen Namen? Ist egal. Ich kann jetzt nicht. Ich bin noch in der Arbeit.",
        "Ist egal. Ich kann jetzt nicht. Ich bin noch in der Arbeit.",
        "TOST",
        "LÜGE",
        "te"
    };

    // Start is called before the first frame update
 // Start is called before the first frame update
void Start()
{

        ds = DialogueSystem.instance;

    // Check if DialogueSystem and its properties are accessible
    if (ds != null && ds.dialogueContainer != null && ds.dialogueContainer.dialogueText != null)
    {
        architect = new TextArchitect(ds.dialogueContainer.dialogueText);
        architect.buildMethod = TextArchitect.BuildMethod.typewriter;
    }
    else
    {
        Debug.LogError("DialogueSystem or its properties are not accessible.");
    }
}   


    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown("space"))
        {
           
            if(architect.isBuilding){

                if(!architect.hurryUp){
                    architect.hurryUp=true;
                }
                
                else{
                    architect.forceComplete();
                    i++;

                }
                
                
            }
            else{
                Debug.Log(lines[0]);
                architect.Build(lines[0]);
                i++;

                }
           // target.GetComponent<MeshRenderer>().enabled = true;



        }
        else if (Input.GetKeyDown(KeyCode.A)){
            architect.Append(lines[Random.Range(0,5)]);
        }
        
    }
}
