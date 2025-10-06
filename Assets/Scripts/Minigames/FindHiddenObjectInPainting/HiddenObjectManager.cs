using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiddenObjectManager : MonoBehaviour
{
    [SerializeField] private List<Button> _hiddenObjects = new List<Button>();


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HiddenObjectClicked(Button hiddenObject)
    {
        if(_hiddenObjects.Contains(hiddenObject))
            hiddenObject.gameObject.SetActive(false);
    }
}
