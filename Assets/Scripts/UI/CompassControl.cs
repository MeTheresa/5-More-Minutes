using UnityEngine;
using UnityEngine.UI;

public class CompassControl : MonoBehaviour
{
    [SerializeField] RawImage _compassDirections;
    [SerializeField] Transform _playerLocation;

    private void Update()
    {
        _compassDirections.uvRect = new Rect(_playerLocation.localEulerAngles.y / 360f ,0f,1f,1f);
    }
}
