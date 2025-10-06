using UnityEngine;

public class PanSpeedManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameManager;
    [SerializeField] private float _speed;
    void Start()
    {
        
    }

    private void Awake()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager");
        _gameManager.GetComponent<TouchController>()._panSpeed = _speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
