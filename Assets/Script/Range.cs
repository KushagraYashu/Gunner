using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{
    public Transform[] spawnPt;
    public GameObject targetGameObject;
    public GameObject GOE, GOM, GOH;
    float i = 0f;
   // public GlobalBoolRange bools;


    IEnumerator Wait(float f)
    {
        yield return new WaitForSeconds(f);
        i++;
    }
    
    public void Easy()
    {
        //i = 0;
        //while (i < 30)
        //{
        Destroy(GOM);
        Destroy(GOH);
        int n = Random.Range(0, spawnPt.Length - 1);
            GOE = Instantiate(targetGameObject, new Vector3(spawnPt[n].transform.position.x, -40f, spawnPt[n].transform.position.z), Quaternion.Euler(0, 90f, 0));
            Destroy(GOE, 3f);
            /*if(GOE == null)
            {
                continue;
            }
            else
            {
                StartCoroutine(Wait(3f));
            }*/
            
        //}
        
    }

    public void Mid()
    {
        Destroy(GOE);
        Destroy(GOH);
        int n = Random.Range(0, spawnPt.Length - 1);
            GOM = Instantiate(targetGameObject, new Vector3(spawnPt[n].transform.position.x, -40f, spawnPt[n].transform.position.z), Quaternion.Euler(0, 90f, 0));
            Destroy(GOM, 2f);
        
    }

    public void Hard()
    {
        Destroy(GOE);
        Destroy(GOM);
        int n = Random.Range(0, spawnPt.Length - 1);
            GOH = Instantiate(targetGameObject, new Vector3(spawnPt[n].transform.position.x, -40f, spawnPt[n].transform.position.z), Quaternion.Euler(0, 90f, 0));
            Destroy(GOH, 1f);
        
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(GOE == null && bools.isEasy)
        {
            Easy();
        }
        if (GOM == null && bools.isMid)
        {
            Mid();
        }
        if (GOH == null && bools.isHard)
        {
            Hard();
        }*/
    }
}
