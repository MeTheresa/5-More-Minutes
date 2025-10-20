using UnityEngine;

public class SideCheckScript : MonoBehaviour, IInteractable
{
    [SerializeField] private bool _IsTragedy = false;

    [SerializeField] private CurtainCallManagerScript _curtainCallManagerScript;


    private float _elapsedTime = 0f;

    public void OnEnable()
    {
        _curtainCallManagerScript.UpdateCurrentActive(1);
    }
    public void OnInteract()
    {
        if (_IsTragedy) CurtainCallManagerScript.TragedyScore += CurtainCallManagerScript.WordPointStrength;
        else CurtainCallManagerScript.ComedyScore += CurtainCallManagerScript.WordPointStrength;
        Deactivate();
    }

    public void Update()
    {
        _elapsedTime += Time.deltaTime;
        WordDeactivator();
    }

    public void OnDisable()
    {
        _elapsedTime = 0;
    }

    private void WordDeactivator()
    {
        if (_elapsedTime >= CurtainCallManagerScript.WordLifetime) Deactivate();
        
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
        _curtainCallManagerScript.UpdateCurrentActive(-1);
    }

}
