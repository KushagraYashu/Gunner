using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RangeThiingyyy : MonoBehaviour
{

    public Easy ezScript;
    public Mid midScript;
    public Hard hardScript;
    public ScoreManager scoreManager;

    public void Start()
    {
        /*ezScript.enabled = false;
        midScript.enabled = false;
        hardScript.enabled = false;*/
    }

    public void Easy()
    {
        scoreManager.curScoreRange = 0;
        scoreManager.UpdateScoreRange(scoreManager.curScoreRange);
        ezScript.enabled = true;
        midScript.enabled = false;
        hardScript.enabled = false;
    }
    public void Mid()
    {
        scoreManager.curScoreRange = 0;
        scoreManager.UpdateScoreRange(scoreManager.curScoreRange);
        ezScript.enabled = false;
        midScript.enabled = true;
        hardScript.enabled = false;
    }
    public void Hard()
    {
        scoreManager.curScoreRange = 0;
        scoreManager.UpdateScoreRange(scoreManager.curScoreRange);
        hardScript.enabled = true;
        ezScript.enabled = false;
        midScript.enabled = false;
    }
    public void DisableAll()
    {
        scoreManager.curScoreRange = 0;
        scoreManager.UpdateScoreRange(scoreManager.curScoreRange);
        ezScript.enabled = false;
        midScript.enabled = false;
        hardScript.enabled = false;
    }

}
