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
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] public List<string> _dialogueDutch = new List<string>();
    [SerializeField] public List<string> _dialogueFrench = new List<string>();
    [SerializeField] public List<string> _dialogueEnglish = new List<string>();

    private bool _dialogueRunning = false;
    private List<string> _dialogue
    {
        get
        {
            switch (GameSettings.Instance.CurrentLanguage)
            {
                case Language.English: return _dialogueEnglish;
                case Language.Dutch: return _dialogueDutch;
                case Language.French: return _dialogueFrench;
                default: return _dialogueEnglish;
            }
        }
    }

    [SerializeField]
    private bool _executeOnStart = false;
    public void Start()
    {
        if (_executeOnStart)
            OnInteract();
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
        _nameText.text = _name;
        _dialogueBox.SetActive(true);
    }

    private IEnumerator HandleDialogue()
    {
        StartDialogue();

        foreach (string dialogue in _dialogue)
        {
            _dialogueText.text = dialogue;
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
        return GameSettings.Instance.TouchAction.action.triggered;
    }
}
