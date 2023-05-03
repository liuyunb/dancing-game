using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class GameManager : Singleton<GameManager>
{
    public bool isDancing;
    
    public ArrowManager arrowHolder;

    public int startLevel = 3;
    public int startTime = 1;

    private int _isGoodInput;

    private void OnEnable()
    {
        EventUtility.GetConfirmKey += ConfirmInput;
        EventUtility.WaveFinish += NextWave;
    }

    private void OnDisable()
    {
        EventUtility.GetConfirmKey -= ConfirmInput;
        EventUtility.WaveFinish -= NextWave;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            arrowHolder.StartDance(startLevel, startTime);
            isDancing = true;
        }

    }

    public void ConfirmArrow()
    {
        arrowHolder.CheckConfirm(_isGoodInput);
    }

    public void InputArrow(KeyCode key)
    {
        arrowHolder.CheckArrow(key);
    }

    #region EventFunction

    public void ConfirmInput(int option)
    {
        _isGoodInput = option;
    }

    public void NextWave()
    {
        arrowHolder.NextWave();
    }

    #endregion

}
