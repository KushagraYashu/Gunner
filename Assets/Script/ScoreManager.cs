using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text text;
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI textRange;
    public int highScoreInt = 0;
    public int curScore = 0;
    public int curScoreRange = 0;

    IEnumerator TextFn(bool resize)
    {
        if (resize)
        {
            text.color = new Color(0, 0, 0, 1);
            for (float i = 60; i > 20; i -= Time.deltaTime * 100)
            {
                text.fontSize = (int)i;
                yield return null;
            }
            yield return new WaitForSeconds(1f);
            StartCoroutine(FadeTxt(true));
        }
    }

    IEnumerator FadeTxt(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                text.color = new Color(0, 0, 0, i);
                yield return null;
            }
            
        }


    }


    void Update()
    {
        if(curScoreRange > highScoreInt)
        {
            highScoreInt = curScoreRange;
            highScore.text = "" + highScoreInt;
        }
        if (Input.GetButtonDown("ClearScore"))
        {
            curScoreRange = 0;
            textRange.text = "" + curScoreRange;
        }    
    }

    public void UpdateScore(int scoreToAdd)
    {
        curScore = scoreToAdd;
        text.text = "" + curScore;
        StartCoroutine(TextFn(true));
        
    }
    public void UpdateScoreRange(int scoreToAdd)
    {
        curScoreRange += scoreToAdd;
        Debug.Log(curScoreRange);
        textRange.text = "" + curScoreRange;
    }
}
