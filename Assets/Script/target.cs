using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public int scoreToAdd;
    public int scoreToAddInRange;
    public float health = 1f;

    public void dead(float h)
    {
        health -= h;
    }

    private void Update()
    {
        if(health <= 0f)
        {
            Destroy(this.transform.parent.gameObject);
        }
    }

}
