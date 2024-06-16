using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Easy : MonoBehaviour
{
    public int bots=0;   
    public GameObject scoreUI;
    public GameObject targetGO;
    public GameObject GOE;
    public Transform[] spawnPt;

    void Awake()
    {
        bots = 0;
    }

    private void Start()
    {
        bots = 0;
    }

    public void EasyFxn()
    {
        if(bots >= 10)
        {
            bots = 0;
            this.GetComponent<Easy>().enabled = false;
        }
        else
        {
            scoreUI.SetActive(true);
            int n = Random.Range(0, spawnPt.Length - 1);
            GOE = Instantiate(targetGO, new Vector3(spawnPt[n].transform.position.x, -43.5f, spawnPt[n].transform.position.z), Quaternion.Euler(0, -90f, 0));
            bots++;
            destroyGOE(3f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(bots);
        if(GOE == null)
        {
            EasyFxn();
        }
    }

    private void OnDisable()
    {
        //scoreUI.SetActive(false);
    }

    public void destroyGOE(float f=0f)
    {
        Destroy(GOE, f);
    }
}
