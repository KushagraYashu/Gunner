using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instructionsManager : MonoBehaviour
{
    public GameObject buyInstructionsUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            buyInstructionsUI.SetActive(false);
        }
    }
}
