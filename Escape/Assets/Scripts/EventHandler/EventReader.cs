using System;
using System.Collections.Generic;
using UnityEngine;
/// \class EventReader
/// \brief Reads all Events from a predefined JSON and stores them in the EventHandler singleton.
public class EventReader : MonoBehaviour
{
    //!Start is called before the first frame update,by doing this we ensure that alle Decisions are loaded before the game "starts".
    public TextAsset json;
    reciever Reciever = reciever.Reciever;
    public void Awake()
    {
        List<JsonEventExample> examples = JSONEventReader.GetJSON(json);
        
        foreach (var example in examples)
        {
            //!Iterate through each json Objet in examples and create a corresponding Decision Object.
            //!Add Decision to reciever._allDecisions.
            string requirment = example._type;
           
            EventEnum _requirment = (EventEnum)Enum.Parse(typeof(EventEnum),requirment);
            EventHandler eventHandler = new EventHandler(example._eventID, _requirment, example._eventstring);
            Debug.Log(eventHandler.GetId  + " " + eventHandler.GetType);
            Reciever.AddEvent(eventHandler);
            
          
        }
    }

    [System.Serializable]
    public class JsonEventExample
    {
        //!According member variables of the Decision Class
        public int _eventID;
        public string _type;
        public string _eventstring;
    }

    public static class JSONEventReader
    {
        public static List<JsonEventExample> GetJSON(TextAsset json)
        {
            // !Wrap the JSON array with a root object to make it parseable
            
            string jsonString = $"{{\"data\":{json.text}}}";
            Debug.Log(jsonString);
            JSONWrapper wrapper = JsonUtility.FromJson<JSONWrapper>(jsonString);
            
            //! Extract the list of JSONExample objects from the root object
            return wrapper.data;
        }

        [System.Serializable]
        private class JSONWrapper
        {
            
            public List<JsonEventExample> data;
        }
    }
}