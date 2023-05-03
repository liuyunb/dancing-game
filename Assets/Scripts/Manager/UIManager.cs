using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public GameObject scorePfb;
    public Transform scorePos;

    public float upTime = 3;

    public Color[] baseColor;

    public void GetScores(int score, float deep)
    {
        StartCoroutine(OnGetScore(score, deep));
    }

    IEnumerator OnGetScore(int score, float deep)
    {
        var scoreGo = Instantiate(scorePfb, scorePos);
        var scoreText = scoreGo.GetComponent<Text>();
        scoreText.text = "+ " + score.ToString();
        Color tempColor = baseColor[Random.Range(0, baseColor.Length)];
        Debug.Log(tempColor);
        scoreText.color = tempColor;
        var time = 0f;

        while (time < upTime)
        {
            time += Time.deltaTime;

            var tempAlpha = Mathf.Clamp(time / upTime, 0, 1);
            
            tempColor.a = (1 - tempAlpha) * 256;
            scoreText.color = tempColor;

            scoreGo.transform.Translate(Vector3.up);

            yield return null;
        }
        
        Destroy(scoreGo);
    }
}
