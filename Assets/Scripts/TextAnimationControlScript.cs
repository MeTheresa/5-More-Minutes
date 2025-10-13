using EasyTextEffects;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI)),RequireComponent(typeof(TextEffect))]
public class TextAnimationControlScript : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private TextEffect _textEffect;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _textEffect = GetComponent<TextEffect>();
    }
    public void DisplayText(string text)
    {
        _text.text = text;
        _textEffect.Refresh();
        _textEffect.StartManualEffects();
    }
}
