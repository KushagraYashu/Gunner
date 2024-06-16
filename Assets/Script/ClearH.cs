using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearH : MonoBehaviour
{
    public RawImage[] marks;

    public void Clear()
    {
        Debug.Log("Clear");
        foreach (var mark in marks)
        {
            Debug.Log("Clear");
            mark.color = new Color(255, 255, 255);
        }
    }
}
