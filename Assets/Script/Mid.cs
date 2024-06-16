using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mid : MonoBehaviour
{
    public GameObject scoreUI;
    public GameObject targetGO;
    public GameObject GOM;
    public Transform[] spawnPt;
    public int bots = 0;
    public void MidFxn()
    {
        if (bots >= 10)
        {
            bots = 0;
            this.GetComponent<Mid>().enabled = false;
        }
        else
        {
            scoreUI.SetActive(true);
            int n = Random.Range(0, spawnPt.Length - 1);
            GOM = Instantiate(targetGO, new Vector3(spawnPt[n].transform.position.x, -43.5f, spawnPt[n].transform.position.z), Quaternion.Euler(0, -90f, 0));
            bots++;
            destroyGOM(2f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GOM == null)
        {
            MidFxn();
        }
    }
    private void OnDisable()
    {
        //scoreUI.SetActive(false);
    }

    public void destroyGOM(float f=0f)
    {
        Destroy(GOM, f);
    }
}
