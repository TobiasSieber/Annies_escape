using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Handy_enable
{
    private GameObject gameObject;
    private Handy handy;
    private MouseHoverCheck mouseHoverCheck;
    [SetUp]
    public void SetUp()
    {
        gameObject = GameObject.Instantiate(new GameObject());
        //handy = gameObject.AddComponent<Handy>();
        
    }
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator Handy_there()
    {
        Assert.IsNotNull(handy);
        
        yield return null;
    }
    [UnityTest]
    public IEnumerator Handy_clicked()
    {
        mouseHoverCheck = gameObject.AddComponent<MouseHoverCheck>();
        //Assert.IsTrue(mouseHoverCheck.foo());
        
        
        yield return null;
    }
}
