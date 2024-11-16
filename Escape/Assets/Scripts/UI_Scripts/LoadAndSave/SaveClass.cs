using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveClass
{
    private Decision.Decision _lastDecision;
    private Inventory _currentInventory;


    public SaveClass(Decision.Decision d, Inventory inventory)
    {
        this._lastDecision = d;
        this._currentInventory = inventory;
    }
    
    public Decision.Decision GetLastDecision
    {
        get { return _lastDecision; }
    }
    public Inventory GetCurrentInventory
    {
        get { return _currentInventory; }
    }
    
    
}
