using UnityEngine;

public class EditFrameElement : MonoBehaviour, IInteractable
{
    public void OnInteract()
    {
        if(transform.parent == null)
            FilmEditData.SelectedObject = this.gameObject;
    }
}
