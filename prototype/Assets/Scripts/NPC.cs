using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{   
    public string[] dialogue;
    public string name;
    public GameObject spellBar;


    //Adding this script to an object allows making dialogues with it
    public override void Interact()
    {
        DialogueSystem.Instance.spellBar = spellBar;
        DialogueSystem.Instance.AddNewDialogue(dialogue, name);
    }

}
