using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Map_test
{
    Handy h1 = Handy.Instanz;

    // A Test behaves as an ordinary method
    [Test]
    public void Handy_singleton()
    {
        Handy h2 = Handy.Instanz;
        Assert.AreEqual(h1, h2);
    }
    [Test]
    public void Handy_openitem()
    {
        int current = h1.get_count()+1;
        h1.open_item();
        Assert.AreEqual(current, h1.get_count());
    }
    [Test]

    public void append_text_while_not_active()
    { 
        h1.DeleteTextHistory();
        h1.close_item();
        string ans = "IAP rocks :)";
        h1.DeleteTextHistory();
        h1.insert_text(ans);
        Assert.AreEqual(h1.return_textHistory(),"Bad req");
    }
    [Test]
    public void append_text_while_active()
    {
        h1.open_item();
        h1.DeleteTextHistory();
        string ans = "IAP rocks :)";
        h1.insert_text(ans);
        Assert.AreEqual(h1.return_textHistory(),ans);
    }

    
 
}
