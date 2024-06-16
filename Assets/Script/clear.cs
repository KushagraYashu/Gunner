using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class clear : MonoBehaviour
{
    public RawImage[] marks;
    public ScoreManager scoreManager;
    
    public void Clear()
    {
        scoreManager.curScoreRange = 0;
        scoreManager.UpdateScoreRange(scoreManager.curScoreRange);
        Debug.Log("Clear");
        foreach (var mark in marks)
        {
            Debug.Log("Clear");
            mark.color = new Color(255, 255, 255);
        }
    }

   

}
