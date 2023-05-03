using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowManager : MonoBehaviour
{
    public GameObject arrowPfb;
    public int levelAddMax;

    public Scroll scrollBar;
    public float moveSpeed = 0.8f;
    
    public bool isFinish;//当前是否完成
    private bool _isSuccess;//当前输入是否成功
    
    private List<Arrow> _arrowList = new List<Arrow>();
    private int _originLevel;
    private int _curLevel;
    private int _curTime = 0;
    private int _curLevelTime;

    private int _curDir;
    private int _curArrowIndex;

    public void StartDance(int level, int time)
    {
        _originLevel = level;
        _curLevel = level;
        _curLevelTime = time;
        _curArrowIndex = 0;
        
        NextWave();
    }

    public void NextWave()
    {
        BeforeNextWave();
        
        _arrowList.Clear();//创建arrow
        for (int i = 0; i < _curLevel; i++)
        {
            var arrow = Instantiate(arrowPfb, transform).GetComponent<Arrow>();
            int dir = Random.Range(0, 4);//0 ↑ 1 ← 2 ↓ 3 →
            arrow.SetUp(dir);
            _arrowList.Add(arrow);
        }

        _curDir = _arrowList[_curArrowIndex].arrowDir;
        _curTime++;
    }

    public void BeforeNextWave()//初始化
    {
        isFinish = false;
        _curArrowIndex = 0;
        _isSuccess = false;

        if (_curTime >= _curLevelTime)
        {
            _curLevelTime++;
            _curTime = 0;
            _curLevel++;
        }

        if (_curLevel > _originLevel + levelAddMax)
        {
            _curLevel = _originLevel;
        }
        
        ClearArrow();
        scrollBar.StartWave(moveSpeed * _curLevel / _originLevel);
    }

    #region CheckInput

    public void CheckArrow(KeyCode key)//检查输入
    {
        if (isFinish)
            return;
        if (ConvertKeycode(key) == _curDir)
        {
            ArrowSuccess();
        }
        else
        {
            ArrowFail();
        }
    }

    public void CheckConfirm(int option)
    {
        //TODO: 以后要判断nice和good
        if (option > 0)
        {
            if (_isSuccess)
            {
                WaveFinish();
            }
            else
            {
                WaveFail();
            }
        }
        else
        {
            WaveFail();
        }
    }

    #endregion
    

    
    
    
    public void WaveSuccess()//wave输入成功
    {
        _isSuccess = true;
    }

    public void WaveFinish()//一个wave完成
    {
        _curArrowIndex = 0;
        isFinish = true;
        UIManager.Instance.GetScores(50 * _curLevel, _curLevel * 1.0f / (_originLevel + levelAddMax));
        ClearArrow();
    }

    public void WaveFail()
    {
        isFinish = true;
        ClearArrow();
    }

    public void ArrowSuccess()//每一个arrow输入成功
    {
        _arrowList[_curArrowIndex].RightInput();
        _curArrowIndex++;

        if(_curArrowIndex >= _arrowList.Count)
            WaveSuccess();
        else
        {
            _curDir = _arrowList[_curArrowIndex].arrowDir;
        }

    }

    public void ArrowFail()//每一个arrow输入失败
    {
        foreach (Transform item in transform)
        {
            var arrow = item.GetComponent<Arrow>();
            arrow.WrongInput();
        }

        _curArrowIndex = 0;
        _curDir = _arrowList[_curArrowIndex].arrowDir;
    }

    public void ClearArrow()//清除所有arrow
    {
        foreach (Transform item in transform)
        {
            Destroy(item.gameObject);
        }
    }

    public int ConvertKeycode(KeyCode key)//将keycode转换成integer
    {
        int result = 0;
        switch (key)
        {
            case KeyCode.UpArrow:
            {
                result = 0;
                break;
            }
            case KeyCode.LeftArrow:
            {
                result = 1;
                break;
            }
            case KeyCode.DownArrow:
            {
                result = 2;
                break;
            }
            case KeyCode.RightArrow:
            {
                result = 3;
                break;
            }
        }

        return result;
    }
}
