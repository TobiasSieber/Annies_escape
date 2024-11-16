using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesint : MonoBehaviour
{
    [SerializeField] private TextAsset fileName;
    // Start is called before the first frame update
    void Start()    
    {
        StartCoroutine(Run());


        IEnumerator Run()
        {
            List<string> lines = FileManager.ReadTextAsset(fileName, true);
            foreach (string line in lines)
            {
                Debug.Log(line);

            }
            
            
            yield return null;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
