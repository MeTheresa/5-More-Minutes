using UnityEngine;
using UnityEngine.InputSystem;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance { get; private set; }

    public InputActionReference TouchPoint;
    public InputActionReference TouchClick;

    [field:SerializeField] public Language CurrentLanguage { get; private set; } = Language.English;
    void Start()
    {
        TouchPoint.action.Enable();
        TouchClick.action.Enable();
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
}
public enum Language
{
    English,
    Dutch,
    French
}