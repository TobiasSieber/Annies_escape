using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// \class Items
/// \brief Abstract class for Items, sets logic for classes which will be used in the item nav bar.
/// 
public abstract class Items 
{
    public abstract bool Active(); //Every Item can be active/not-active, there fore included in the class
    public abstract void open_item(); 
    public abstract void close_item();


}
 