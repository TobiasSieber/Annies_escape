using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// \class Handy
/// \brief Represents a singleton item with text history management functionality.
///
/// The `Handy` class is a derived class from `Items` that implements a singleton design pattern.
/// It manages an active state, tracks usage count, and allows text input while maintaining a text history.
/// The class ensures only one instance of `Handy` exists at any given time.
///
/// \author [Your Name]
public class Handy : Items
{
    /// \brief Singleton instance of the `Handy` class.
    private static Handy _instance;

    /// \brief Tracks the number of times the item has been opened.
    private static int _count;

    /// \brief Stores the text history associated with the item.
    private static string _textHistory;

    /// \brief Tracks whether the item is currently active.
    private bool _active;

    /// \brief Private constructor to enforce singleton design pattern.
    private Handy()
    {
    }

    /// \brief Retrieves the singleton instance of the `Handy` class.
    /// 
    /// \details
    /// If the instance doesn't already exist, it is created. Subsequent calls will return the same instance.
    ///
    /// \return The singleton instance of the `Handy` class.
    public static Handy Instanz
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Handy();
            }

            return _instance;
        }
    }

    /// \brief Checks whether the item is active.
    /// 
    /// \details
    /// This overrides the `Active` method from the base `Items` class.
    ///
    /// \return `true` if the item is active; otherwise, `false`.
    public override bool Active()
    {
        return _active;
    }

    /// \brief Activates the item and increments the usage count.
    ///
    /// \details
    /// This overrides the `open_item` method from the base `Items` class.
    public override void open_item()
    {
        _count++;
        _active = true;
    }

    /// \brief Deactivates the item.
    ///
    /// \details
    /// This overrides the `close_item` method from the base `Items` class.
    public override void close_item()
    {
        _active = false;
    }

    /// \brief Appends text to the item's text history.
    ///
    /// \details
    /// If the item is active, the provided string is appended to `_textHistory`. 
    /// If the item is not active, the string `"Bad req"` is appended instead.
    ///
    /// \param str The string to be added to the text history.
    public void insert_text(string str)
    {
        if (_active)
        { 
            _textHistory += str;
        }
        else
        {
            _textHistory += "Bad req";
        }
    }

    /// \brief Retrieves the usage count of the item.
    ///
    /// \return The number of times the item has been opened.
    public int get_count()
    {
        return _count;
    }

    /// \brief Retrieves the text history of the item.
    ///
    /// \return The text history as a `string`.
    public string return_textHistory()
    {
        return _textHistory;
    }

    /// \brief Clears the text history of the item.
    public void DeleteTextHistory()
    {
        _textHistory = "";
    }
}
