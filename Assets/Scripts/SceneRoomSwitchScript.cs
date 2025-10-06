using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRoomSwitchScript : MonoBehaviour
{
    //Scene 0 = Prototype
    //Scene 1 = InteractablePersonTest
    //Scene 2 = Shaders&Assets
    //Scene 3 = Test
    //Scene 4 = FindObjectsInPainting Minigame
    //Scene 5 = PaintingRoom
    //Scene 6 = Prototype - Adam
    public static void LoadSceneOrMinigame(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
