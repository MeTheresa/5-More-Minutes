using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Touch Action Reference")]
    [SerializeField]
    private float _panSpeed = 10f;
    private float _touchDepth = 10f;

    private Vector3 _touchLocation;

    public Vector3 TouchLocation { get => _touchLocation; set { _touchLocation = value; } }


    // Update is called once per frame
    void Update()
    {
        TouchLocationTracker();
        GetInteractable();
        PanCamera();
    }

    private void PanCamera()
    {
        if (GameSettings.Instance.TouchClick.action.IsPressed())
        {
            if (GameSettings.Instance.TouchPoint.action.ReadValue<Vector2>().x < Screen.width / 4)
                Camera.main.transform.position -= Vector3.right * _panSpeed * Time.deltaTime;
            if (GameSettings.Instance.TouchPoint.action.ReadValue<Vector2>().x > Screen.width - Screen.width / 4)
                Camera.main.transform.position += Vector3.right * _panSpeed * Time.deltaTime;
        }
    }

    private Vector3 TouchToWorld(Vector3 TouchCoordinate) //Convert the screen point to world point
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(TouchCoordinate.x, TouchCoordinate.y, _touchDepth));
    }

    private void TouchLocationTracker() // Update the touch location when the screen is being touched
    {
        if (GameSettings.Instance.TouchPoint.action.triggered)
        {
            TouchLocation = TouchToWorld(GameSettings.Instance.TouchPoint.action.ReadValue<Vector2>());
        }
    }
    private Ray TouchRay() //Get ray from camera to touch location
    {
        return new Ray(Camera.main.transform.position, (TouchLocation - Camera.main.transform.position).normalized);
    }



    public void GetInteractable() //Raycast to get the first interactable gameObject
    {
        if (Physics.Raycast(TouchRay(), out RaycastHit hit, Mathf.Infinity, LayerMask.GetMask("Interactable")) && GameSettings.Instance.TouchClick.action.WasReleasedThisFrame())
        {
            if (hit.collider.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                interactable.OnInteract();
            }
        }
        
    }
}
