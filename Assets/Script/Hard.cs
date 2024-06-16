using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Hard : MonoBehaviour
{
    public GameObject scoreUI;
    public GameObject targetGO;
    public GameObject GOH;
    public Transform[] spawnPt;
    public int bots = 0;

    public void HardFxn()
    {
        if (bots >= 10)
        {
            bots = 0;
            this.GetComponent<Hard>().enabled = false;
        }
        else
        {
            scoreUI.SetActive(true);
            int n = Random.Range(0, spawnPt.Length - 1);
            GOH = Instantiate(targetGO, new Vector3(spawnPt[n].transform.position.x, -43.5f, spawnPt[n].transform.position.z), Quaternion.Euler(0, -90f, 0));
            bots++;
            destroyGOH(1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GOH == null)
        {
            HardFxn();
        }
    }
    private void OnDisable()
    {
       // scoreUI.SetActive(false);
    }

    public void destroyGOH(float f = 0f)
    {
        Destroy(GOH, f);
    }
}
