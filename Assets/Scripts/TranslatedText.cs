using NUnit.Framework;
using System;
using UnityEngine;

[Serializable]
public class TranslatedText
{
    [SerializeField] private string _french;
    [SerializeField] private string _dutch;
    [SerializeField] private string _english;
    public string Text { 
        get
        {
            switch (GameSettings.Instance.CurrentLanguage)
            {
                case Language.English: return _english;
                case Language.Dutch: return _dutch;
                case Language.French: return _french;
                default: return _english;
            }
        } }
}
