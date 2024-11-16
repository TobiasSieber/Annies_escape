using System.Collections.Generic;
using Text_Scripts;
using UnityEngine;

public class TextReciever {
    
    private static TextReciever _textreciever;
    readonly Dictionary<uint, Text> _allDecisions = new Dictionary<uint,Text>();


    private TextReciever()
    {


    }

    //!Reciever is build by the singleton design pattern
    public static TextReciever textReciever
    {
        get
        {
            if (_textreciever == null)
            {
                _textreciever = new TextReciever();
            }

            return _textreciever;
        }
    }
    
    public void AddTText(Text d)
    {
        if (!_allDecisions.ContainsKey(d.GetDecisionID()))
        {
            //! Add a decision to _allDecisions.
            _allDecisions.Add(d.GetDecisionID(),d);
            return;
        }
     
    }
    
    public  Text GetTText(uint textID)
    {
        //!Retrieves a specific Decision which is identified by the unique decisionID
        return _allDecisions[textID];
    }

    public  int Size()
    {
        return _allDecisions.Count;
    }

  
    public void Droptable()
    {
        _allDecisions.Clear();
    }

    
}
