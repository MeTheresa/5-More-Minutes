using UnityEngine;

public class FilmSpot : MonoBehaviour, IInteractable
{
    [SerializeField] private int _positionNumber;
    public void OnInteract()
    {
        if(FilmEditData.SelectedObject != null)
        {
            FilmEditData.SelectedObject.transform.SetPositionAndRotation(this.transform.position, this.transform.rotation);
            FilmEditData.FrameOrder[_positionNumber] = FilmEditData.SelectedObject.GetComponentInChildren<SpriteRenderer>();
            FilmEditData.SelectedObject.transform.parent = this.transform.parent;
        }
    }    
}
