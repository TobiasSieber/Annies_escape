using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Assertions;

public class LoadFile : MonoBehaviour
{
    // Start is called before the first frame update
    private storage storage;
    private Inventory inventory;
    public TextAsset json;
    public DecisionLoader decisionLoader;
    public ClickDecision clickDecision;


    // Update is called once per frame


    private void OnMouseDown()
    {
        storage = storage.Storage;
        inventory = Inventory.inventory;
        Debug.Log("Called");
        RootObject data = JsonConvert.DeserializeObject<RootObject>(json.text);
        LoadInventory(data);
        LoadGameState(data);
        Debug.Log(storage.returnLast().GetdecisionDescription());
    }

    private void LoadInventory(RootObject data)
    {
        inventory.DropInventory();
        foreach (var VARIABLE in data.GetCurrentInventory)
        {

            inventory.AddtoInventory((AllItems)Enum.Parse(typeof(AllItems), VARIABLE));
        }
    }

    private void LoadGameState(RootObject data)
    {
        storage.DropStorage(); //!We ensure that the storage is empty before calling file
        Decision.Decision d = new Decision.Decision(data.GetLastDecision.GetDecisionID(),data.GetLastDecision.GetdecisionDescription(), data.GetLastDecision.GetFollowText(),
            data.GetLastDecision.GetTimeOutVal(), data.GetLastDecision.GetTriggerOut(),data.GetLastDecision.GetdecisionCall(),data.GetLastDecision.GetDecisionFamily(),
            data.GetLastDecision.GetRequirment(), data.GetLastDecision.GetReward());
            storage.AddDecision(d);
            decisionLoader.LoadTextintoObject(d.GetdecisionCall());
            clickDecision.SetRoundExtern((d.GetdecisionCall()*4)-3);
    }
    [System.Serializable]

    public class DecisionJSON
    {
        public int DecisionID { get; set; }
        public string DecisionDescription { get; set; }
        public string DecisionFollowtext { get; set; }
        public double DecisiontimeoutVal { get; set; }
        public bool DecisiontriggerOut { get; set; }
        public int Decisionrequirment { get; set; }
        public int Decisionreward { get; set; }
        public int DecisionCall { get; set; }
        public int DecisionFamily { get; set; }
    }

    public class InventoryJSON
    {
        public List<string> GetCurrentInventory { get; set; }
    }

    public class RootObject
    {
        public Decision.Decision GetLastDecision { get; set; }
        public List<string> GetCurrentInventory { get; set; }
    }

}
