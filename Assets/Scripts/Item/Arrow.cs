using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    public Sprite[] arrowsImage;
    private Image _arrowImg;
    public int arrowDir;
    public Color rightColor;
    private Color _oriColor;
    private void Awake()
    {
        _arrowImg = GetComponent<Image>();
        _oriColor = _arrowImg.color;
    }

    public void SetUp(int dir)
    {
        _arrowImg.sprite = arrowsImage[dir];
        arrowDir = dir;
        _arrowImg.SetNativeSize();
    }

    public void RightInput()
    {
        _arrowImg.color = rightColor;
    }

    public void WrongInput()
    {
        _arrowImg.color = _oriColor;
    }
}
