using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript Instance;
    public Material ShaderMaterial;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        //if (SceneManager.GetActiveScene().buildIndex == 4) //find objects in painting
        //{
        //    ShaderMaterial.SetFloat("ColorThreshhold", 0);
        //}
        //else
        //{
        //    ShaderMaterial.SetFloat("ColorThreshhold", 2);
        //}
    }
}
