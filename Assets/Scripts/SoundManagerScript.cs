using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;
    [Header("Audio Clips")]
    public AudioClip FutureStartStop;
    public AudioClip PastVynilStart;
    public AudioClip PastVynilStop;
    public AudioClip PresentRadioStart;
    public AudioClip PresentRadioStop;

    public static SoundManagerScript Instance;
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //musicSource.clip = something;
        //musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
