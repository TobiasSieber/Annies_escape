using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Inventory_test
{
    Inventory Inventory = Inventory.inventory;
    
    [Test]
    public void AddtoInventory_test()
    {
        
        Inventory.AddtoInventory(AllItems.Taschenlampe);
      
    }
    
    
      
    [Test]
    public void ItemContainedInInventory()
    {
        
        Inventory.AddtoInventory(AllItems.Taschenlampe);
        //!With one item in inventory
        Assert.AreEqual(true,Inventory.contains(AllItems.Taschenlampe));
        Inventory.DropInventory();
    }
    
    [Test]
    public void DropInventory()
    {
        
        Inventory.AddtoInventory(AllItems.Taschenlampe);
        Inventory.DropInventory();
        Assert.AreEqual(false,Inventory.contains(AllItems.Taschenlampe));
    }
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
  
}
