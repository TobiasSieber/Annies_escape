using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Line
{
    public DL_Dialogue_DATA dialogue;
    public DL_COMMAND_DATA commands;

    public bool hasDialogue => dialogue.hasDialogue;
   
    public bool hasCommands => commands != null;
    public Dialogue_Line(string dialogue, string commands)
    {
        this.dialogue = new DL_Dialogue_DATA(dialogue);
        this.commands = (string.IsNullOrWhiteSpace(commands) ? null : new DL_COMMAND_DATA(commands));
    }

}
