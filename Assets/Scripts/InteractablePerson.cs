using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InteractablePerson : MonoBehaviour, IInteractable
{
    [SerializeField] private string _name;
    [SerializeField] private Texture2D _visual;
    [SerializeField] private RawImage _dialogueVisualReference;
    [SerializeField] private GameObject _dialogueBox;
    [SerializeField] private TextAnimationControlScript _dialogueText;
    [SerializeField] private TextAnimationControlScript _nameText;
    [SerializeField] private List<TranslatedText> _dialogue = new List<TranslatedText>();

    private bool _dialogueRunning = false;

    [SerializeField]
    private bool _executeOnStart = false;
    public void Start()
    {
        if (_executeOnStart)
            OnInteract();
        else
            _dialogueRunning = false;
    }
    public virtual void OnInteract()
    {
        if (!_dialogueRunning)
            StartCoroutine(HandleDialogue());
    }

    private void StartDialogue()
    {
        _dialogueRunning = true;
        _dialogueVisualReference.texture = _visual;
        _dialogueBox.SetActive(true);
        _nameText.DisplayText(_name);
    }

    private IEnumerator HandleDialogue()
    {
        StartDialogue();

        foreach (TranslatedText dialogue in _dialogue)
        {
            _dialogueText.DisplayText(dialogue.Text);
            yield return new WaitForEndOfFrame();
            yield return new WaitForSecondsRealtime(0.1f);
            yield return new WaitUntil(ButtonInput);
            yield return new WaitForEndOfFrame();
        }

        EndDialogue();

        yield return null;
    }

    private void EndDialogue()
    {
        _dialogueRunning = false;
        _dialogueBox.SetActive(false);
    }

    private bool ButtonInput()
    {
        return GameSettings.Instance.TouchClick.action.WasReleasedThisFrame();
    }
}
