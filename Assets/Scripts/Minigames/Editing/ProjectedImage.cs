using UnityEngine;

public class ProjectedImage : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (FilmStrip.Lerping)
            _spriteRenderer.sprite = FilmEditData.FrameOrder[FilmStrip.FrameNumber - 1].sprite;
        else
            _spriteRenderer.sprite=null;
    }
}
