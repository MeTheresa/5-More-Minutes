using EasyTextEffects.Editor.MyBoxCopy.Extensions;
using UnityEngine;

public class FilmStrip : MonoBehaviour
{
    private float _lerper = 0;
    public static bool Lerping = false;
    [SerializeField] private float _lerpSpeed;
    [SerializeField] private Vector3 _lerpStart;
    [SerializeField] private Vector3 _lerpEnd;
    [SerializeField] private int _frameAmount;
    private float _frameWorldDistance;
    public static int FrameNumber = 0;
    private int _frameCompensator = 5; //FrameNumber Starts at 5 because of _frameWorldDistance, make up for it with this variable

    private void Start()
    {
        _frameWorldDistance = Mathf.Abs(_lerpStart.x - _lerpEnd.x)/_frameAmount; //Calculates distance strip needs to move to change frame on projector
    }

    public void ExecuteFilm()
    {
       Lerping = true;
    }

    private void Update()
    {
        if( Lerping)
        {
            FrameNumber = (int)(_lerpStart.x - transform.position.x / _frameWorldDistance) - _frameCompensator;
            Debug.Log(FrameNumber);
            _lerper += Time.deltaTime*_lerpSpeed;
            transform.position = Vector3.Lerp(_lerpStart, _lerpEnd, _lerper);
            if(_lerper > 1)
                Lerping = false;
        }
        else
        {
            if (_lerper != 0)
                _lerper = 0;
        }
    }
}
