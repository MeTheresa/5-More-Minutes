using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public class NotePresenter : PresenterBaseClass<NoteModel>
{
    [SerializeField] private Image fillObject;
    public RectTransform Transform { get; private set; }
    public float MovementSpeed { get; private set; }

    public void Initialize(RectTransform transform, float movementSpeed, Vector2 noteSpawnPosition)
    {
        Transform = transform;
        MovementSpeed = movementSpeed;
        Model = new NoteModel(MovementSpeed, noteSpawnPosition);
    }

    protected override void Model_PropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
    {
        if (propertyChangedEventArgs.PropertyName.Equals(nameof(NoteModel.Transform)))
        {
            UpdatePosition();
        }
        if (propertyChangedEventArgs.PropertyName.Equals(nameof(NoteModel.State)))
        {
            UpdateStateVisual();
        }
    }

    public void Update()
    {
        if (GameSettings.Instance.TouchClick.action.IsPressed())
        {
            Model.TapRequested();
        }
    }

    private void UpdateStateVisual()
    {
        if (Model.State == NoteModel.NoteState.InTiming || Model.State == NoteModel.NoteState.Completed)
        {
            fillObject.enabled = true;
        }
        else
        {
            fillObject.enabled = false;
        }
    }

    private void UpdatePosition()
    {
        Transform.anchoredPosition = Model.Transform;
    }

    protected override void ModelSetInitialization(NoteModel previousModel)
    {
        base.ModelSetInitialization(previousModel);
    }
}
