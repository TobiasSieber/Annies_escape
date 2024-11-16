using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Flags]
public enum AllItems
{
    //! Item enum, used for declaring events in a central way
    Bag    = 0b_0000_000000,  // 0
    Feuerzeug = 0b_0000_0000001,
    Taschenlampe = 0b_0000_000010,
    Haarzeug = 0b_00000_000100,
    Schere = 0b_0000_001000,
    Haarspray = 0b_000001_0000,
    Messer = 0b_000010_0000,
    Schlüsselbund = 0b_000100_0000,
    Knife = 0b_001000_0000





}