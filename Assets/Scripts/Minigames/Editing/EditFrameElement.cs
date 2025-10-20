using UnityEngine;

public class EditFrameElement : MonoBehaviour, IInteractable
{
    public void OnInteract()
    {
        FilmEditData.SelectedObject = this.gameObject;
    }
}
