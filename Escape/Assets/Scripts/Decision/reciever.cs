using System;
using System.Collections.Generic;
using UnityEngine;

/// \class reciever
/// \brief Holds all possible decisions and events, implemented as a singleton.
public class reciever : TextHolder
{
    //! Singleton instance of the reciever class.
    private static reciever _reciever;

    //! Dictionary storing all possible decisions, mapped by unique decision IDs.
    Dictionary<uint, Decision.Decision> allDecisions = new Dictionary<uint, Decision.Decision>();

    //! Dictionary storing all events, mapped by event IDs.
    Dictionary<int, EventHandler> allEvents = new Dictionary<int, EventHandler>();

    //! Private constructor to restrict instantiation.
    private reciever() { }

    //! Provides access to the singleton instance of the reciever class.
    public static reciever Reciever
    {
        get
        {
            if (_reciever == null)
            {
                _reciever = new reciever();
            }
            return _reciever;
        }
    }

    //! Adds a decision to allDecisions if it doesn’t already exist.
    /*!
        \param d The Decision object to add.
    */
    public override void AddDecision(Decision.Decision d)
    {
        if (!allDecisions.ContainsKey(d.GetDecisionID()))
        {
            allDecisions.Add(d.GetDecisionID(), d);
        }
    }

    //! Retrieves a specific decision by its unique decisionID.
    /*!
        \param decisionID The ID of the decision to retrieve.
        \return The Decision object corresponding to the provided decisionID.
    */
    public override Decision.Decision GetDecision(uint decisionID)
    {
        return allDecisions[decisionID];
    }

    //! Returns the total number of decisions stored.
    /*!
        \return The count of decisions in allDecisions.
    */
    public override int Size()
    {
        return allDecisions.Count;
    }

    //! Clears all stored decisions from the dictionary.
    public void Droptable()
    {
        allDecisions.Clear();
    }

    //! Adds an event to allEvents.
    /*!
        \param eventHandler The EventHandler object to add.
    */
    public void AddEvent(EventHandler eventHandler)
    {
        allEvents.Add(eventHandler.GetId, eventHandler);
    }

    //! Checks if an event exists for a specific decision.
    /*!
        \param d The Decision object to check for an associated event.
        \return True if an event exists for the decision, false otherwise.
    */
    public bool EventExists(Decision.Decision d)
    {
        Debug.Log(allEvents.ContainsKey(145));
        return allEvents.ContainsKey(Convert.ToInt16(d.GetDecisionID()));
    }

    //! Retrieves a specific event by its ID.
    /*!
        \param id The ID of the event to retrieve.
        \return The EventHandler object corresponding to the provided ID or a default EventHandler if not found.
    */
    public EventHandler GetEvent(uint id)
    {
        if (allDecisions.ContainsKey(id))
        {
            return allEvents[Convert.ToInt16(id)];
        }
        return new EventHandler(0, EventEnum.inventory, "NAN");
    }

    //! Checks if a specific event exists in allEvents.
    /*!
        \param eventHandler The EventHandler object to check.
        \return True if the event exists, false otherwise.
    */
    public bool containsEvent(EventHandler eventHandler)
    {
        return allEvents.ContainsKey(eventHandler.GetId);
    }
}
