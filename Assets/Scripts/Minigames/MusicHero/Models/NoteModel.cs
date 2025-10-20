using UnityEngine;

public class NoteModel : UnityModelBaseClass
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _completedColor;
    private NoteState _state;
    public NoteState State
    {
        get { return _state; }
        set
        {
            if (_state == value) return;
            _state = value;
            OnPropertyChanged();
        }
    }
    private Vector2 _transform; 
    public Vector2 Transform
    {
        get { return _transform; }
        set
        {
            if (_transform == value) return;
            Vector2 oldTransform = _transform;
            _transform = value;
            OnPropertyChanged();
        }
    }
    public NoteModel(float movementSpeed, Vector2 spawnPosition)
    {
        _movementSpeed = movementSpeed;
        Transform = spawnPosition;
    }
    public void TapRequested()
    {
        if (State == NoteState.InTiming)
        {
            State = NoteState.Completed;
            Debug.Log("Completed Note");
        }
    }
    public void Update()
    {
        Transform -= new Vector2(_movementSpeed * Time.deltaTime, 0);
    }
    public enum NoteState
    {
        Idle,
        InTiming,
        Completed
    }
}
