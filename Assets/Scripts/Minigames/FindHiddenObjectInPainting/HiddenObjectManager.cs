using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HiddenObjectManager : MonoBehaviour
{
    [SerializeField] private List<Button> _hiddenObjects = new List<Button>();
    [SerializeField] private TextMeshProUGUI _objectsLeft;

    void Start()
    {
        UpdateHiddenObjectCountText(_hiddenObjects.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateHiddenObjectCountText(int newCount)
    {
        _objectsLeft.text = ("Objects left: " + newCount);

        if(newCount < 1)
        {
            _objectsLeft.text = ("Objects left: " + newCount + ", well done!");
        }
    }

    public void HiddenObjectClicked(Button hiddenObject)
    {
        if (_hiddenObjects.Contains(hiddenObject))
        {
            hiddenObject.gameObject.SetActive(false);
            _hiddenObjects.Remove(hiddenObject);
            UpdateHiddenObjectCountText(_hiddenObjects.Count);
        }

    }
}
