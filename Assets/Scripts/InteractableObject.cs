using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableObject : MonoBehaviour, IInteractable
{
    [SerializeField] private string _sceneName;
    //Scene 0 = Prototype
    //Scene 1 = InteractablePersonTest
    //Scene 2 = Shaders&Assets
    //Scene 3 = Test
    //Scene 4 = FindObjectsInPainting Minigame
    public void OnInteract()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
