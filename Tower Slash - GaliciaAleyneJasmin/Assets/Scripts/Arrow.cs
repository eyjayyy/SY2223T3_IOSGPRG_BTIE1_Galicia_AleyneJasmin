using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    public int currentSprite;
    [SerializeField] private Image image;
    [SerializeField] private Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        currentSprite = Random.Range(0, sprites.Length - 1);
        image.sprite = sprites[currentSprite];
    }
}
