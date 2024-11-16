
using NUnit.Framework;


public class Decision_Test
{
    Decision.Decision d1 = new Decision.Decision(1, "Go to the cave","nan",0,false, 1, 1,AllItems.Bag,AllItems.Bag);
    Decision.Decision d2 = new Decision.Decision(2, "Drink from the river", "nan",0,false, 1, 1,AllItems.Bag,AllItems.Bag);
    Decision.Decision d3 = new Decision.Decision(3, "Jump over the hill", "nan",0,false, 1, 1,AllItems.Bag,AllItems.Bag);
    Decision.Decision d4 = new Decision.Decision(4, "Hide", "nan",0,false, 1, 1,AllItems.Bag,AllItems.Bag);
    Decision.Decision d5 = new Decision.Decision(5, "Explore the forest", "nan",0,false, 1, 1,AllItems.Bag,AllItems.Bag);
    Decision.Decision d6 = new Decision.Decision(6, "Climb a tree", "nan",0,false, 1, 1,AllItems.Bag,AllItems.Bag);
    Decision.Decision d7 = new Decision.Decision(7, "Follow the path", "nan",0,false, 1, 1,AllItems.Bag,AllItems.Bag);
    Decision.Decision d8= new Decision.Decision(8, "Go home", "nan",0,false, 1, 1,AllItems.Bag,AllItems.Bag);
    reciever reciever = reciever.Reciever;
    storage storage = storage.Storage;

    private void prepareData()
    {
        reciever.Droptable();
        storage.Droptable();
        reciever.AddDecision(d1);
        reciever.AddDecision(d2);
        reciever.AddDecision(d3);
        reciever.AddDecision(d4);
        reciever.AddDecision(d5);
        reciever.AddDecision(d6);
        reciever.AddDecision(d7);
        reciever.AddDecision(d8);
    }


    [Test]
    public void init_reciever_storage()
    {
        reciever reciever2 = reciever.Reciever;
        storage storage2 = storage.Storage;
        Assert.AreEqual(reciever,reciever2);
        Assert.AreEqual(storage,storage2);
       
    }
    
    
    
    [Test]
    public void Read_JSONTest() //!Since we're calling our initial data preperation in an gameobject, calling it here seems quiet difficult, hence we do it in such a pseudo way
    {
        prepareData();
        Assert.AreEqual(reciever.Size(),8); //!Test if each decision is stored correctly, hence size=#decision
    }

    [Test]
    public void Reciever_to_StorageTest()
    {
        storage.AddDecision(reciever.GetDecision(1)); //!reciever pushed to storage 
        
        Assert.IsNotNull(storage.GetDecision(1));
    }

    [Test]
    public void change_Decision()
    {
        //!We ensure this by not creating any setters
    }

    [Test]
    public void make_decision()
    {
        storage.AddDecision(d1);
        Assert.AreEqual(storage.Size(),1);
        Decision.Decision dnew = d1;
        storage.AddDecision(dnew);
        Assert.AreEqual(storage.Size(),1); //! Since dnew is the same decision should not be added
        
    }




}

