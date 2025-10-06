using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Touch Action Reference")]
    [SerializeField]
    private InputActionReference _touchAction;
    [SerializeField]
    private float _panSpeed = 10f;
    private float _touchDepth = 10f;

    private Vector3 _touchLocation;

    public Vector3 TouchLocation { get => _touchLocation; set { _touchLocation = value; } }

    void Start()
    {
        _touchAction.action.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        TouchLocationTracker();
        GetInteractable();

    }

    private Vector3 TouchToWorld(Vector3 TouchCoordinate) //Convert the screen point to world point
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(TouchCoordinate.x, TouchCoordinate.y, _touchDepth));
    }

    private void TouchLocationTracker() // Update the touch location when the screen is being touched
    {
        if (_touchAction.action.triggered)
        {
            TouchLocation = TouchToWorld(_touchAction.action.ReadValue<Vector2>());
        }
    }
    private Ray TouchRay() //Get ray from camera to touch location
    {
        return new Ray(Camera.main.transform.position, (TouchLocation - Camera.main.transform.position).normalized);
    }



    public void GetInteractable() //Raycast to get the first interactable gameObject
    {
        if (Physics.Raycast(TouchRay(), out RaycastHit hit, Mathf.Infinity, LayerMask.GetMask("Interactable")) && _touchAction.action.triggered)
        {
            Debug.Log("Hit: " + hit.collider.name);
            if (hit.collider.gameObject.CompareTag("Panner"))
            {
                Camera.main.transform.position += new Vector3(hit.collider.gameObject.transform.localPosition.x, 0, 0) * _panSpeed  * Time.deltaTime;
            }
        }
        
    }
}
