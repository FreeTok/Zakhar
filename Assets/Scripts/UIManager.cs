using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite[] images;
    public Image img;

    private int activeImage;
    private RectTransform rt;

    private void Awake()
    {
        rt = img.GetComponent(typeof(RectTransform)) as RectTransform;
        SetElement(0);
    }

    public void Next()
    {
        SetElement(1);
    }

    public void Back()
    {
        SetElement(-1);
    }

    private void SetElement(int i)
    {
        if (activeImage + i < 0)
        {
            activeImage = images.Length - activeImage + i;
        }

        else if (activeImage + i >= images.Length)
        {
            activeImage = 0;
        }

        else
        {
            activeImage += i;
        }

        img.sprite = images[activeImage];
        rt.sizeDelta = new Vector2(images[activeImage].rect.width, images[activeImage].rect.height);
    }
}
