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
        
    }

    // Update is called once per frame
    void Update()
    {
        _objectsLeft.text = ("Objects left: " + _hiddenObjects.Count.ToString());
    }

    public void HiddenObjectClicked(Button hiddenObject)
    {
        if (_hiddenObjects.Contains(hiddenObject))
        {
            hiddenObject.gameObject.SetActive(false);
            _hiddenObjects.Remove(hiddenObject);
        }

    }
}
