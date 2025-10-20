using UnityEngine;

public class SideCheckScript : MonoBehaviour, IInteractable
{
    [SerializeField] private bool _IsTragedy = false;

    public void OnInteract()
    {
        if (_IsTragedy) CurtainCallManagerScript.ComedyScore += 5f;
        else CurtainCallManagerScript.TragedyScore += 5f;

    }

}
