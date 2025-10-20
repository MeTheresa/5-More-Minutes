using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CurtainCallManagerScript : MonoBehaviour
{
    CurtainCallManagerScript _curtainCallManager;
    private static float _wordPointStrength = 5f;

    private static float _wordLifetime = 1f;

    private static float _tragedyScore = 5f;

    private static float _comedyScore = 5f;

    public static float WordPointStrength
    { 
     get { return _wordPointStrength; }
     set { _wordPointStrength = value; }
    }
    
    public static float WordLifetime
    {
        get { return _wordLifetime; }
        set { _wordLifetime = value; }
    }
    public static float TragedyScore 
    {
        get { return _tragedyScore; } 

        set {
            if (value > 90 || value < 0) return; 
            _tragedyScore = value;
            Debug.Log(_tragedyScore);
            } 
    }
    public static float ComedyScore 
    { 
        get { return _comedyScore; } 
        set 
        { 
            if (value > 90 || value < 0) return;
            _comedyScore = value;
        } 
    }

    [Header("Gauge assignment objects")]
    [SerializeField] private RectTransform LeftGauge;
    [SerializeField] private RectTransform RightGauge;

    [Header("Score drain adjustment")]
    [SerializeField] private float _drainSpeed = 1f; //
    [SerializeField] private float _drainStrength = 1f;
    [SerializeField] private float _distancedStrengthIncrease = 3f;

    [Header("List of objects for positioning")]
    [SerializeField] private List<GameObject> _words;
    //[SerializeField] private List<GameObject> _comedies; // list of specified per type for applying custom text
    //[SerializeField] private List<GameObject> _tragedies;

    private int _currentActive = 0;
    private float _elapsedTime = 0;


    private string[] _tragedyEng;
    private string[] _comedyEng;
    private Vector2 _anchorPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _curtainCallManager = this;
        _tragedyEng = new string[] { "Sadness", "Vitriol", "Grief", "Longing"};
        _comedyEng = new string[] { "Joy", "Laugh", "Celebration", "Happiness" };
        _anchorPoint = this.gameObject.transform.position;
        foreach (GameObject word in _words)
        {
            word.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

        ChooseRandomWord();
        UpdateGauges();
        Debug.Log(_currentActive);
    }

    private void ChooseRandomWord()
    {
        if(_currentActive < 2)
      {
            int random =  Mathf.CeilToInt(Random.Range(-1f, 7f));
        if(random == -1)
        {
            ChooseRandomWord();
        }
            if (_words[random].activeSelf == false)
                ActivateWord(random);
        }
    }

    private void ActivateWord(int listPosition)
    {
        _words[listPosition].SetActive(true);
    }
    private void UpdateGauges()
    {
        UpdateRightGauge(RightGauge);
        UpdateLeftGauge(LeftGauge);
        if (_elapsedTime >= _drainSpeed) GaugeFalloff();
        _elapsedTime += Time.deltaTime;

    }

    private void UpdateLeftGauge(RectTransform rightGauge)
    {
        float ActualLeftGauge = -90 + TragedyScore;
        rightGauge.transform.localPosition = new Vector3(0, ActualLeftGauge, 0);
    }

    private void UpdateRightGauge(RectTransform leftGauge)
    {
        float ActualRightGauge = -90 + ComedyScore;
        leftGauge.transform.localPosition = new Vector3(0, ActualRightGauge, 0);
    }

    public void UpdateCurrentActive(int activeDelta)
    {
        _currentActive += activeDelta;
    }

    private void GaugeFalloff()
    {
        if (TragedyScore > ComedyScore && Mathf.Abs(TragedyScore - ComedyScore) > 10) TragedyScore -= _distancedStrengthIncrease;
        else TragedyScore -= _drainStrength;
        if (ComedyScore > TragedyScore && Mathf.Abs(TragedyScore - ComedyScore) > 10) ComedyScore -= _distancedStrengthIncrease;
        else ComedyScore -= _drainStrength;
        _elapsedTime = 0;
    }
}
