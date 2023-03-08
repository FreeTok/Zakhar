using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

[Serializable]
public struct img
{
    public Sprite image;
    public string question, firstAnswerText, secondAnswerText, firstAnswer, secondAnswer;
    public Vector2 size;

    public void SetEl(Image imageToSet, RectTransform rt, TextMeshProUGUI firstText, TextMeshProUGUI secondText, TextMeshProUGUI questionText)
    {
        imageToSet.sprite = image;

        rt.sizeDelta = size;
        
        firstText.SetText(firstAnswerText);
        secondText.SetText(secondAnswerText);
        questionText.SetText(question);
    }
}


public class UIManager : MonoBehaviour
{
    [Space]
    public img[] images;
    public Image img;

    private int activeImage;
    private RectTransform rt;
    
    [Space]
    public TextMeshProUGUI finishText, question, firstText, secondText;
    private string finish;

    private void Awake()
    {
        rt = img.GetComponent(typeof(RectTransform)) as RectTransform;
        SetElement(0);
    }

    public void Next(int index)
    {
        switch (index)
        {
            case 0:
            {
                finish += images[activeImage].firstAnswer;
                
                break;
            }
            
            case 1:
            {
                finish += images[activeImage].secondAnswer;
                
                break;
            }
        }
        
        SetElement(1);
    }

    private void Finish()
    {
        print("Finish");
        
        finishText.transform.parent.gameObject.SetActive(true);
        img.transform.parent.gameObject.SetActive(false);
        finishText.SetText(finish);
    }
    

    private void SetElement(int i)
    {
        print(i);
        if (activeImage + i >= images.Length)
        {
            Finish();

        }

        else
        {
            activeImage += i;
        }

        images[activeImage].SetEl(img, rt, firstText, secondText, question);
    }
}
