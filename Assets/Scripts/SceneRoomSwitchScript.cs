using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRoomSwitchScript : MonoBehaviour
{
    //Scene 0 = Prototype - Adam
    //Scene 1 = Prototype
    //Scene 2 = InteractablePersonTest
    //Scene 3 = Shaders&Assets
    //Scene 4 = Test
    //Scene 5 = FindObjectsInPainting Minigame
    //Scene 6 = PaintingRoom

    public static void LoadSceneOrMinigame(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
