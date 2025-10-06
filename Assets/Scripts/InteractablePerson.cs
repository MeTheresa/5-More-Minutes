using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractablePerson : IInteractable
{
    [SerializeField] private string _name;
    [SerializeField] private GameObject _visual;
    [SerializeField] private List<string> _dialogue = new List<string>();
    private int _dialogueIndex = 0;

    public virtual void OnInteract()
    {
        
    }

    private IEnumerator HandleDialogue()
    {

        yield return null;
    }
}
