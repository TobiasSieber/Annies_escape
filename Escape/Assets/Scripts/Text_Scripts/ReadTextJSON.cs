using System.Collections.Generic;
using Text_Scripts;
using UnityEngine;

public class ReadTextJSON : MonoBehaviour
{
    //!Start is called before the first frame update,by doing this we ensure that alle Decisions are loaded before the game "starts".
    public TextAsset json;
    TextReciever textReciever = TextReciever.textReciever;
    public void Awake()
    {
        List<JSONExample> examples = JSONReader.GetJSON(json);
        
        foreach (var example in examples)
        {
            //!Iterate through each json Objet in examples and create a corresponding Decision Object.
            //!Add Decision to reciever._allDecisions.
            Text t = new Text(example._ttextID, example._ttextDescription);
            textReciever.AddTText(t);
        }
    }

    [System.Serializable]
    public class JSONExample
    {
        //!According member variables of the Decision Class
        public uint _ttextID;
        public string _ttextDescription;
    }

    public static class JSONReader
    {
        public static List<JSONExample> GetJSON(TextAsset json)
        {
            // !Wrap the JSON array with a root object to make it parseable
            string jsonString = $"{{\"data\":{json.text}}}";
            JSONWrapper wrapper = JsonUtility.FromJson<JSONWrapper>(jsonString);

            //! Extract the list of JSONExample objects from the root object
            return wrapper.data;
        }

        [System.Serializable]
        private class JSONWrapper
        {
            
            public List<JSONExample> data;
        }
    }
}