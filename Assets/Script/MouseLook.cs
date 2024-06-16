using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Start is called before the first frame update

    public Gun gunScript;
    public float camRecoilMin = 1f;
    public float camRecoilMax = 5f;
    public float gunRecoil = .5f;
    public float mouseSens = 100f;
    public Transform[] gun;
    float xRotation = 0f;
    public Transform playerBody;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -60f, 60f);

       // var val = xRotation - camRecoil;
        var val2 = xRotation - gunRecoil;

       /* if (gunScript.firing)
        {
            camRecoilMin = 1f;
            camRecoilMax = 5f;
        }
        else
        {
            camRecoilMin = camRecoilMax = 0f;
            
        }*/

        //if (gunScript.firing)
       // {
            transform.localRotation = Quaternion.Euler(xRotation /*- Random.Range(camRecoilMin,camRecoilMax)*/, 0f, 0f);
        foreach(var gun in gun)
        {
            gun.localRotation = Quaternion.Euler(0f, 90f, xRotation);
        } //- gunRecoil);
        //}
        /*else
        {
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            gun.localRotation = Quaternion.Euler(0f, 90f, xRotation);
        }*/
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
