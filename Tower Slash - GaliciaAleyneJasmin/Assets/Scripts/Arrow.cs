using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    public int currentSprite;
    [SerializeField] private Image image;
    [SerializeField] private Sprite[] sprites;

    public void GetArrow()
    {
        currentSprite = Random.Range(0, sprites.Length);
        image.sprite = sprites[currentSprite];
        Debug.Log("Arrow is " + currentSprite);
    }

    public IEnumerator CO_RotateArrow()
    {
        while(!GetComponentInParent<Enemy>().isAttacking)
        {
            yield return new WaitForSeconds(0.3f);
            image.sprite = sprites[currentSprite];
            currentSprite++;
            
            if (currentSprite > sprites.Length - 1)
            {
                currentSprite = 0;
            }
        }

        GetArrow();
    }
}
