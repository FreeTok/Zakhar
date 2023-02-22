using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

[Serializable]
public struct img
{
    public Sprite image;
    public VideoClip video;

    public void SetEl(Image imageToSet, VideoPlayer videoImg, RectTransform rt)
    {
        if (video)
        {
            if (imageToSet.gameObject.activeSelf) imageToSet.gameObject.SetActive(false);
            if (!videoImg.gameObject.activeSelf) videoImg.gameObject.SetActive(true);

            videoImg.clip = video;
            videoImg.isLooping = true;
            videoImg.Play();
        }

        else
        {
            if (!imageToSet.gameObject.activeSelf) imageToSet.gameObject.SetActive(true);
            if (videoImg.gameObject.activeSelf) videoImg.gameObject.SetActive(false);

            imageToSet.sprite = image;

            rt.sizeDelta = new Vector2(image.rect.width, image.rect.height);
        }
    }
}


public class UIManager : MonoBehaviour
{
    public img[] images;
    public Image img;
    public VideoPlayer videoImg;

    private int activeImage;
    private RectTransform rt;

    private void Awake()
    {
        print(img.gameObject.activeSelf);
        print(videoImg.gameObject.activeSelf);

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
        print(i);
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

        images[activeImage].SetEl(img, videoImg, rt);
    }
}
