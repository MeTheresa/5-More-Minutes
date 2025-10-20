using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class NoteSpawner : MonoBehaviour 
{
    [SerializeField] private GameObject _noteObject;
    [SerializeField] private Vector2 _noteSpawnPosition;
    [SerializeField] private Transform _notesParent;
    [SerializeField] private Vector2 _timeZone;
    public List<NoteModel> _notes = new List<NoteModel>();

    [SerializeField] private List<NoteData> _notesSong = new List<NoteData>();

    private AudioSource _audioSource;
    private int _nextNoteIndex = 0;

    public void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
    }
    public void SpawnNote(NoteData note)
    {
        GameObject newNote = Instantiate(_noteObject, _notesParent);

        RectTransform rect = newNote.GetComponent<RectTransform>(); 
        rect.anchoredPosition = _noteSpawnPosition;

        NotePresenter newNotePresenter = newNote.GetComponent<NotePresenter>();
        newNotePresenter.Initialize(rect, note.speed, note.spawnPosition);
        _notes.Add(newNotePresenter.Model);
    }
    private void Update()
    {
        HandleNoteSpawning();
        HandleTimingZone();
    }

    private void HandleTimingZone()
    {
        foreach (NoteModel model in _notes)
        {
            model.Update();
            if (model.Transform.x < _timeZone.x && model.Transform.x > _timeZone.y)
            {
                if (model.State == NoteModel.NoteState.Idle)
                {
                    model.State = NoteModel.NoteState.InTiming;
                }
            }
            else
            {
                if (model.State == NoteModel.NoteState.InTiming)
                {
                    model.State = NoteModel.NoteState.Idle;
                }
            }
        }
    }

    private void HandleNoteSpawning()
    {
        if (_nextNoteIndex >= _notesSong.Count)
            return;

        float songTime = _audioSource.time;

        NoteData next = _notesSong[_nextNoteIndex];
        if (songTime >= next.time)
        {
            SpawnNote(next);
            _nextNoteIndex++;
        }

    }
}
[Serializable]
public class NoteData
{
    public float time;
    public Vector2 spawnPosition = new Vector2(1010, 0);
    public float speed = 200;
}
