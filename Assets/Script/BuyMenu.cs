using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BuyMenu : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    public DepthOfField dOF;
    private float initialFocusValue;

    public static bool buying = false;

    public GameObject buyMenuUI;
    public GameObject playaRelUI;
    
    public WeaponMaster weaponMaster;

    private void Start()
    {
        postProcessVolume.profile.TryGetSettings(out dOF);
        initialFocusValue = dOF.focusDistance.value;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (buying)
            {
                UnloadBuyMenu();
            }
            else
            {
                LoadBuyMenu();
            }
        }
    }

    void UnloadBuyMenu()
    {
        dOF.focusDistance.value = initialFocusValue;
        Cursor.lockState = CursorLockMode.Locked;
        buyMenuUI.SetActive(false);
        playaRelUI.SetActive(true);
        Time.timeScale = 1f;
        buying = false;
    }

    void LoadBuyMenu()
    {
        dOF.focusDistance.value = 1f;
        Cursor.lockState = CursorLockMode.None;
        buyMenuUI.SetActive(true);
        playaRelUI.SetActive(false);
        Time.timeScale = 0f;
        buying = true;
    }

    public void EnableWeapon(int i)
    {
        weaponMaster.weaponEnabled[i] = true;
        UnloadBuyMenu();

    }
}
