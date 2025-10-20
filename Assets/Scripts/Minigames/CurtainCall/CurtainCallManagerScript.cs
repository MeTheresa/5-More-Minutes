using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CurtainCallManagerScript : MonoBehaviour
{

    private static float _tragedyScore = 5f;

    private static float _comedyScore = 5f;

    public static float TragedyScore 
    {
        get { return _tragedyScore; } 

        set {
            if (value > 90 || value < 0) return; 
            else _tragedyScore = value;
            } 
    }
    public static float ComedyScore 
    { 
        get { return _comedyScore; } 
        set 
        { 
            if (value > 90 || value < 0) return;
            else _comedyScore = value;
        } 
    }

    [Header("Gauge objects")]
    [SerializeField] private RectTransform LeftGauge;
    [SerializeField] private RectTransform RightGauge;

    [Header("List of objects for positioning")]
    [SerializeField] private List<GameObject> _tragedies;
    [SerializeField] private List<GameObject> _comedies;

    private List<GameObject> _currentActive = new();

    private string[] _tragedyEng;
    private string[] _comedyEng;
    private Vector2 _anchorPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _tragedyEng = new string[] { "Sadness", "Vitriol", "Grief", "Longing"};
        _comedyEng = new string[] { "Joy", "Laugh", "Celebration", "Happiness" };
        _anchorPoint = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGauges();
    }

    private void UpdateGauges()
    {
        UpdateRightGauge(RightGauge);
        UpdateLeftGauge(LeftGauge);
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

    public Vector2 GetRandomNonOverlappingPosition()
    {
        Vector2 Position = GenerateRandomPosition();
        if (CheckOverlap(Position))
        {
            GetRandomNonOverlappingPosition();
            throw new System.Exception("Recursion skipped");
        }
        else return Position;
    }

    public Vector3 GenerateRandomPosition()
    {
        Vector2 random = Random.insideUnitCircle;
        return new Vector3(random.x, random.y, -90f);
    }
    public bool CheckOverlap(Vector3 Position)
    {
        if( _currentActive.Count == 0 )    return false;
        
        foreach (var @object in _currentActive)
        {
            if (@object.transform.position == Position)
            {
                return true;
            }
            else
                return false;
        }

        throw new System.Exception("Conditional skipped");
    }
}
