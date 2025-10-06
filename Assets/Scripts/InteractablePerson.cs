using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InteractablePerson : MonoBehaviour, IInteractable
{
    [SerializeField] private string _name;
    [SerializeField] private Texture2D _visual;
    [SerializeField] private RawImage _dialogueVisualReference;
    [SerializeField] private GameObject _dialogueBox;
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] public List<string> _dialogue = new List<string>();
    [SerializeField] private bool _executeOnStart = false;
    public void Start()
    {
        if (_executeOnStart)
        OnInteract();
    }
    public virtual void OnInteract()
    {
        StartCoroutine(HandleDialogue());
    }

    private void StartDialogue()
    {
        _dialogueVisualReference.texture = _visual;
        _nameText.text = _name;
        _dialogueBox.SetActive(true);
    }

    private IEnumerator HandleDialogue()
    {
        StartDialogue();

        foreach (string dialogue in _dialogue)
        {
            _dialogueText.text = dialogue;
            yield return new WaitUntil(ButtonInput);
            yield return new WaitForEndOfFrame();
        }

        EndDialogue();
        
        yield return null;
    }

    private void EndDialogue()
    {
        _dialogueBox.SetActive(false);
    }

    private bool ButtonInput()
    {
        return Input.GetMouseButtonUp(0);
    }
}
