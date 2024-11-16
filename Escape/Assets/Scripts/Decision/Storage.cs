using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// \class storage
/// \brief Manages decision storage using a singleton pattern, allowing only one instance of storage to exist.
public class storage : TextHolder
{
    //! Singleton instance of storage class.
    private static storage _storage;

    //! Dictionary for fast access to stored decisions, mapped by unique decision IDs.
    Dictionary<uint, Decision.Decision> myMap = new Dictionary<uint, Decision.Decision>();

    //! Private constructor to restrict instantiation of storage class.
    private storage() { }

    //! Provides access to the singleton instance of the storage class.
    public static storage Storage
    {
        get
        {
            if (_storage == null)
            {
                _storage = new storage();
            }
            return _storage;
        }
    }

    //! Adds a decision object to the dictionary if it doesn't already exist.
    /*!
        \param d The Decision object to add.
    */
    public override void AddDecision(Decision.Decision d)
    {
        if (!myMap.ContainsKey(d.GetDecisionID()))
        {
            myMap.Add(d.GetDecisionID(), d);
        }
    }

    //! Retrieves a specific decision by its unique decisionID.
    /*!
        \param decisionID The ID of the decision to retrieve.
        \return The Decision object corresponding to the provided decisionID.
    */
    public override Decision.Decision GetDecision(uint decisionID)
    {
        return myMap[decisionID];
    }

    //! Prints all stored decisions to the console for debugging purposes.
    public void getAllDecision()
    {
        foreach (KeyValuePair<uint, Decision.Decision> kvp in myMap)
        {
            uint key = kvp.Key;
            Decision.Decision decision = kvp.Value;
            Debug.Log($"Key: {key}, Description: {decision.GetdecisionDescription()}");
        }
    }

    //! Checks if a specific decision exists in the dictionary.
    /*!
        \param d The Decision object to check.
        \return True if the decision exists, false otherwise.
    */
    public Boolean contains(Decision.Decision d)
    {
        return myMap.ContainsKey(d.GetDecisionID());
    }

    //! Returns the total number of stored decisions.
    /*!
        \return The count of decisions in the storage.
    */
    public override int Size()
    {
        return myMap.Count;
    }

    //! Clears all stored decisions from the dictionary.
    public void Droptable()
    {
        myMap.Clear();
    }

    //! Returns the most recently added decision based on the highest decisionID.
    /*!
        \return The last Decision object added to the storage.
    */
    public Decision.Decision returnLast()
    {
        return GetDecision(myMap.Keys.Max());
    }

    //! Clears all stored decisions, effectively dropping the storage.
    public void DropStorage()
    {
        myMap.Clear();
    }
}
