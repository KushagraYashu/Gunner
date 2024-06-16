using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject PauseMenuUI;
    public PostProcessVolume postProcessVolume;
    public DepthOfField dOF;
    public GameObject playerRelUI;
    public static bool gamePaused;
    private float initialFocusValue;


    private void Start()
    {
        postProcessVolume.profile.TryGetSettings(out dOF);
        initialFocusValue = dOF.focusDistance.value;
    }

    // Update is called once per frame  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        dOF.focusDistance.value = initialFocusValue;
        Cursor.lockState = CursorLockMode.Locked;
        PauseMenuUI.SetActive(false);
        playerRelUI.SetActive(true);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    void Pause()
    {
        dOF.focusDistance.value = 1f;
        Cursor.lockState = CursorLockMode.None;
        PauseMenuUI.SetActive(true);
        playerRelUI.SetActive(false);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        gamePaused = false;
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
