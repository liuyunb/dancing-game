using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class Scroll : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;

    public Transform goodScorePoint;

    public float targetTime = 4;
    public float delayTime = 1.0f;

    public AnimationCurve curve = new AnimationCurve();
    
    private Vector3 _startPos;
    private Vector3 _endPos;
    private Vector3 _goodScorePos;
    private float _goodScoreWidth;

    private bool _isScore;


    private void Awake()
    {
        _startPos = startPoint.position;
        _endPos = endPoint.position;
        _goodScorePos = goodScorePoint.position;
        _goodScoreWidth = ((RectTransform) goodScorePoint).rect.width;
    }

    private Coroutine _startScroll = null;

    IEnumerator StartScroll(float moveSpeed)
    {
        float time = 0;
        
        transform.position = _startPos;

        while (Vector3.Distance(transform.position, _endPos) > 0.1f)
        {
            var percent = Mathf.Clamp(time / targetTime, 0, 1);
            time += Time.deltaTime * moveSpeed;
            transform.position = Vector3.Lerp(_startPos, _endPos, percent);
            
            yield return null;
        }
        
        EventUtility.OnWaveFinish();
    }

    public void StartWave(float moveSpeed)
    {
        if (_startScroll != null)
        {
            StopCoroutine(_startScroll);
            _startScroll = null;
        }

        _startScroll = StartCoroutine(StartScroll(moveSpeed));
    }

    private void Update()
    {
        checkScore();
    }

    public void checkScore()
    {
        var x = transform.position.x;
        if (x > _goodScorePos.x && x < _goodScorePos.x + _goodScoreWidth)
        {
            if (!_isScore)
            {
                EventUtility.OnGetConfirmKey(1);
                _isScore = true;
            }
        }
        else if(_isScore)
        {
            _isScore = false;
            EventUtility.OnGetConfirmKey(0);
        }
    }
}
