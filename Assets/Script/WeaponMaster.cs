using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponMaster : MonoBehaviour
{
    public GameObject[] weapons;
    public static bool equipEnable = true;
    public GameObject playerUI;
    
    public bool[] equipped;
    public bool[] weaponEnabled;

    private void Start()
    {
        
    }
    
    void OtherWeaponCheck(int j)
    {
        for(int i = 0; i < weapons.Length; i++)
        {
            if (i == j)
            {
                continue;
            }
            else
            {
                if (equipped[i])
                {
                    weapons[i].SetActive(false);
                    equipped[i] = false;
                }
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && weaponEnabled[0] && PauseMenu.gamePaused == false && equipEnable)
        {
            Debug.Log("oen");
            OtherWeaponCheck(0);
            if (equipped[0])
            {
                weapons[0].SetActive(false);
                equipped[0] = false;
            }
            else if(!equipped[0])
            {
                weapons[0].SetActive(true);
                equipped[0] = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && weaponEnabled[2] && PauseMenu.gamePaused == false && equipEnable)
        {
            try 
            {
                if (gameObject.GetComponentInChildren<Gun>().isScoped)
                {

                }
                else
                {
                    Debug.Log("oen");
                    OtherWeaponCheck(2);
                    if (equipped[2])
                    {
                        weapons[2].SetActive(false);
                        equipped[2] = false;
                    }
                    else if (!equipped[2])
                    {
                        weapons[2].SetActive(true);
                        equipped[2] = true;
                    }
                }
            }
            catch
            {
                Debug.Log("oen");
                OtherWeaponCheck(2);
                if (equipped[2])
                {
                    weapons[2].SetActive(false);
                    equipped[2] = false;
                }
                else if (!equipped[2])
                {
                    weapons[2].SetActive(true);
                    equipped[2] = true;
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && weaponEnabled[1] && PauseMenu.gamePaused == false && equipEnable)
        {
            Debug.Log("oen");
            OtherWeaponCheck(1);
            if (equipped[1])
            {
                weapons[1].SetActive(false);
                equipped[1] = false;
            }
            else if (!equipped[1])
            {
                weapons[1].SetActive(true);
                equipped[1] = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && weaponEnabled[3] && PauseMenu.gamePaused == false && equipEnable)
        {
            Debug.Log("oen");
            OtherWeaponCheck(3);
            if (equipped[3])
            {
                weapons[3].SetActive(false);
                equipped[3] = false;
            }
            else if (!equipped[3])
            {
                weapons[3].SetActive(true);
                equipped[3] = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && weaponEnabled[4] && PauseMenu.gamePaused == false && equipEnable)
        {
            Debug.Log("oen");
            OtherWeaponCheck(4);
            if (equipped[4])
            {
                weapons[4].SetActive(false);
                equipped[4] = false;
            }
            else if (!equipped[4])
            {
                weapons[4].SetActive(true);
                equipped[4] = true;
            }
        }if (Input.GetKeyDown(KeyCode.Alpha6) && weaponEnabled[5] && PauseMenu.gamePaused == false && equipEnable)
        {
            Debug.Log("oen");
            OtherWeaponCheck(5);
            if (equipped[5])
            {
                weapons[5].SetActive(false);
                equipped[5] = false;
            }
            else if (!equipped[5])
            {
                weapons[5].SetActive(true);
                equipped[5] = true;
            }
        }

    }
}
