using UnityEngine;
using UnityEngine.InputSystem;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance { get; private set; }

    public InputActionReference TouchAction;

    [field:SerializeField] public Language CurrentLanguage { get; private set; } = Language.English;
    void Start()
    {
        TouchAction.action.Enable();
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