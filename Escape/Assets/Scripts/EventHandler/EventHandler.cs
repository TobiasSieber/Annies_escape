using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// \class EventHandler
/// \brief Manages events by encapsulating their ID, type, and associated data.
///
/// The `EventHandler` class represents a game event, storing essential details such as its unique ID,
/// type, and an associated string for additional information. This class provides access to these properties
/// and facilitates event-driven architecture.
///
/// \details
/// Events in the game are categorized by their type (e.g., inventory changes or notifications). Each event
/// has a unique identifier (ID) and an optional string to convey extra details, such as descriptions or
/// notifications displayed to the player.
///
/// \author []
public class EventHandler
{
    /// \brief Unique identifier for the event.
    private int _eventID;

    /// \brief Type of the event, defined by the `EventEnum`.
    private EventEnum _type;

    /// \brief Additional information associated with the event, stored as a string.
    private string _eventstring;

    /// \brief Constructs an EventHandler with the specified ID, type, and string.
    /*!
        \param eventID The unique identifier for the event.
        \param type The type of the event, categorized using `EventEnum`.
        \param eventstring Additional data or description for the event.
    */
    public EventHandler(int eventID, EventEnum type, string eventstring)
    {
        this._eventID = eventID;
        this._type = type;
        this._eventstring = eventstring;
    }

    /// \brief Retrieves the type of the event.
    /*!
        \return The `EventEnum` representing the type of the event.
    */
    public EventEnum GetType
    {
        get { return _type; }
    }

    /// \brief Retrieves the unique ID of the event.
    /*!
        \return The integer value representing the unique event ID.
    */
    public int GetId
    {
        get { return _eventID; }
    }

    /// \brief Retrieves the string associated with the event.
    /*!
        \return A string containing additional information about the event.
    */
    public string GetString
    {
        get { return _eventstring; }
    }

    /// \enum EventClass
    /// \brief Defines high-level categories of events.
    ///
    /// The `EventClass` enum provides broad classifications for events,
    /// such as inventory updates or user notifications.
    public enum EventClass
    {
        /// \brief Events related to inventory changes.
        inventory,

        /// \brief Events related to player notifications.
        notification,
    }
}
