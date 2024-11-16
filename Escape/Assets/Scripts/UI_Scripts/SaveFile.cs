using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

public class SaveFile : MonoBehaviour
{
    // Start is called before the first frame update
    private storage storage;
    
    
    private void OnMouseDown()
    {   
           StoreFile();

    }

    private void StoreFile()
    {
        storage = storage.Storage;
        Inventory inventory = Inventory.inventory;
        SaveClass saveClass = new SaveClass(storage.returnLast(), inventory);
        saveClass.show();
        string path = Application.dataPath + "/saveFile.json";
        string SaveClassJSON = JsonConvert.SerializeObject(saveClass, Formatting.Indented);
        File.WriteAllText(path,SaveClassJSON);
    }
    
    public class SaveClass
    {
        private Decision.Decision _lastDecision;
        private List<String> _currentItems;

        public SaveClass(Decision.Decision d, Inventory inventory)
        {
            this._lastDecision = d;
            _currentItems = new List<string>();
            foreach (var VARIABLE in Enum.GetValues(typeof(AllItems)))
            {
                AllItems item  = (AllItems)Enum.Parse(typeof(AllItems), VARIABLE.ToString());
                if (inventory.contains(item))
                {
                    Debug.Log("Confirmed in inventory: " + item);
                    Debug.Log(VARIABLE.ToString());
                    this._currentItems.Add(VARIABLE.ToString());
                    
                }
            }
        }
    
        public Decision.Decision GetLastDecision
        {
            get { return _lastDecision; }
        }
        public List<String> GetCurrentInventory
        {
            get { return _currentItems; }
        }

        public void show()
        {
            foreach (var VARIABLE in _currentItems)
            {
                Debug.Log(VARIABLE);
            }
        }
    
    }
}


