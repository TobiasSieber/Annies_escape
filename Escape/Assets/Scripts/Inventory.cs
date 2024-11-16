using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// \class Inventory
/// \brief Manages the player's inventory using a singleton pattern.
public class Inventory
{
    //! Singleton instance of the Inventory class.
    private static Inventory _inventory;

    //! Current items in the inventory, stored as a bitwise combination of AllItems.
    private AllItems current_items = AllItems.Bag;

    //! Private constructor to restrict instantiation.
    private Inventory() { }

    //! Provides access to the singleton instance of the Inventory class.
    public static Inventory inventory
    {
        get
        {
            if (_inventory == null)
            {
                _inventory = new Inventory();
            }
            return _inventory;
        }
    }

    //! Public getter for the current inventory items.
    public AllItems InventoryItem
    {
        get { return current_items; }
    }

    //! Displays the current items in the inventory to the console.
    public void Show()
    {
        Debug.Log(current_items);
    }

    //! Adds a new item to the inventory using bitwise OR.
    /*!
        \param x The item to add to the inventory.
    */
    public void AddtoInventory(AllItems x)
    {
        this.current_items = current_items | x;
    }

    //! Checks if a specific item is contained in the inventory using bitwise AND.
    /*!
        \param item The item to check for in the inventory.
        \return True if the item is in the inventory, false otherwise.
    */
    public bool contains(AllItems item)
    {
        if ((current_items & item) == item)
        {
            return true;
        }
        return false;
    }

    //! Retrieves the current items in the inventory.
    /*!
        \return The current items in the inventory.
    */
    public AllItems GetCurrentItems()
    {
        return this.current_items;
    }

    //! Resets the inventory, keeping only the Bag item.
    /*!
        Since Annie will always have a Bag, this method effectively clears all items except the Bag.
    */
    public void DropInventory()
    {
        this.current_items = AllItems.Bag;
    }
}
