using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public bool firing = false;
    public float scopedFOV = 15f;
    private float normalFOV;
    public PlayerMovement playaMov;
    public float gunPara;
    public Animator gunAnim;
    public bool isScoped = false;
    public GameObject scopeOverlay;
    public GameObject cross;
    public float damage = 10f;
    public float offset = 10f;
    public ScoreManager scoreManager;
    public Camera cam;
    public GameObject bulletHole;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public float fireRate = 1f;
    [SerializeField] private float nextTimeToFire = 0f;
    private bool isReloading = false;
    private int currentAmmo;
    public int clipSize = 30;
    public float reloadTime = 5f;
    public Text curAmmoText;
    public RangeThiingyyy daThingy;
    public RawImage head;
    public RawImage torso;
    public RawImage lHand;
    public RawImage rHand;
    public RawImage lLeg;
    public RawImage rLeg;


    public AudioSource soundEffect;
    public AudioSource reloadEffect;


    private void Start()
    { 
        currentAmmo = clipSize;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(currentAmmo == 0)
        {
            StartCoroutine(Reload());
            return;
        }*/
        
        playaMov.gunPara = gunPara;
        if (isReloading)
            return;

        if (currentAmmo < clipSize && Input.GetButtonDown("Reload"))
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && currentAmmo > 0 && PauseMenu.gamePaused == false)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            firing = true;
            gunAnim.SetBool("firing", firing);
            Shoot();
        }
        if(Input.GetButtonDown("Fire2") && currentAmmo >= 0 && PauseMenu.gamePaused == false && transform.name == "300 Magnum")
        {
            
            isScoped = !isScoped;
            gunAnim.SetBool("Scoped", isScoped);
            cross.SetActive(!isScoped);
            
            if (isScoped)
            {
                WeaponMaster.equipEnable = false;
                StartCoroutine(OnScoped());
            }
            else
            {
                WeaponMaster.equipEnable = true;
                onUnscoped();
            }

            
        }
        if (BuyMenu.buying && isScoped)
        {
            isScoped = false;
            gunAnim.SetBool("Scoped", isScoped);
            cross.SetActive(false);
            onUnscoped();
        }
        
        

        curAmmoText.text = "" + currentAmmo;

    }


    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(.1f);
        scopeOverlay.SetActive(true);
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        normalFOV = cam.fieldOfView;
        cam.fieldOfView = scopedFOV;
    }
    void onUnscoped()
    {
        //yield return new WaitForSeconds(.15f);
        scopeOverlay.SetActive(false);
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        cam.fieldOfView = normalFOV;
    }

    private void OnDisable()
    {
        playaMov.gunPara = 1f;
    }

    IEnumerator Reload()
    {
        isReloading = true;
        reloadEffect.Play();
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = clipSize;
        isReloading = false;
    }

    IEnumerator Delay(float f)
    {
        yield return new WaitForSeconds(f);
    }

    void Shoot()
    {
        
        /*var x = transform.localRotation.x;
       // firing = true;
        if (recoil>0f)
        {
            cam.transform.localRotation = Quaternion.Euler(transform.localRotation.x - Random.Range(camRecoilMin, camRecoilMax), 0f, 0f);
            recoil -= Time.deltaTime;
        }
        else
        {
            cam.transform.localRotation = Quaternion.Euler(x, 0f, 0f);
        }*/
        currentAmmo--;
        muzzleFlash.Play();
        soundEffect.Play();
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
        {
            
            Debug.Log(hit.transform.name);
            if(hit.transform.tag != "boundary")
            {
                GameObject bulletHoleGO = Instantiate(bulletHole, hit.point + (hit.normal / 1000), Quaternion.LookRotation(hit.normal));
                bulletHoleGO.transform.parent = hit.transform;
                Destroy(bulletHoleGO, 10f);
                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f);
            }
            if (hit.transform.name == "White")
            {

                hit.transform.GetComponent<target>().scoreToAdd = 100;
                scoreManager.UpdateScore(hit.transform.GetComponent<target>().scoreToAdd);
                hit.transform.GetComponent<target>().scoreToAdd = 0;
                hit.transform.GetComponent<target>().dead(10f);
            }
            if (hit.transform.name == "Blue")
            {

                hit.transform.GetComponent<target>().scoreToAdd = 75;
                scoreManager.UpdateScore(hit.transform.GetComponent<target>().scoreToAdd);
                hit.transform.GetComponent<target>().scoreToAdd = 0;
                hit.transform.GetComponent<target>().dead(10f);
            }
            if (hit.transform.name == "Yellow")
            {

                hit.transform.GetComponent<target>().scoreToAdd = 50;
                scoreManager.UpdateScore(hit.transform.GetComponent<target>().scoreToAdd);
                hit.transform.GetComponent<target>().scoreToAdd = 0;
                hit.transform.GetComponent<target>().dead(10f);
            }
            if (hit.transform.name == "Red")
            {

                hit.transform.GetComponent<target>().scoreToAdd = 25;
                scoreManager.UpdateScore(hit.transform.GetComponent<target>().scoreToAdd);
                hit.transform.GetComponent<target>().scoreToAdd = 0;
                hit.transform.GetComponent<target>().dead(10f);
            }
            if (hit.transform.name == "B-head")
            {

                hit.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
                if (!hit.transform.CompareTag("PracticeBot"))
                {
                    hit.transform.GetComponent<target>().scoreToAddInRange = 100;
                    scoreManager.UpdateScoreRange(hit.transform.GetComponent<target>().scoreToAddInRange);
                    hit.transform.GetComponent<target>().scoreToAddInRange = 0;

                    if (daThingy.ezScript.enabled)
                    {
                        daThingy.ezScript.destroyGOE();
                    }
                    else if (daThingy.midScript.enabled)
                    {
                        daThingy.midScript.destroyGOM();
                    }
                    else if (daThingy.hardScript.enabled)
                    {
                        daThingy.hardScript.destroyGOH();
                    }
                }
            }
            if ((hit.transform.name == "B-chest" || hit.transform.name == "B-forearm_L" || hit.transform.name == "B-forearm_R") )
            {

                hit.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
                if (!hit.transform.CompareTag("PracticeBot"))
                {
                    hit.transform.GetComponent<target>().scoreToAddInRange = 75;
                    scoreManager.UpdateScoreRange(hit.transform.GetComponent<target>().scoreToAddInRange);
                    hit.transform.GetComponent<target>().scoreToAddInRange = 0;
                    if (daThingy.ezScript.enabled)
                    {
                        daThingy.ezScript.destroyGOE();
                    }
                    else if (daThingy.midScript.enabled)
                    {
                        daThingy.midScript.destroyGOM();
                    }
                    else if (daThingy.hardScript.enabled)
                    {
                        daThingy.hardScript.destroyGOH();
                    }
                }
            }
            if ((hit.transform.name == "B-shin_L" || hit.transform.name == "B-shin_R"))
            {

                hit.transform.GetComponent<target>().scoreToAddInRange = 50;
                if(!hit.transform.CompareTag("PracticeBot")) { 
                scoreManager.UpdateScoreRange(hit.transform.GetComponent<target>().scoreToAddInRange);
                hit.transform.GetComponent<target>().scoreToAddInRange = 0;
                if (daThingy.ezScript.enabled)
                {
                    daThingy.ezScript.destroyGOE();
                }
                else if (daThingy.midScript.enabled)
                {
                    daThingy.midScript.destroyGOM();
                }
                else if (daThingy.hardScript.enabled)
                {
                    daThingy.hardScript.destroyGOH();
                }
                }
            }
            if (hit.transform.name == "I10M")
            {
                if (!(hit.transform.GetComponent<RawImage>().color == new Color(255, 0, 0)))
                {
                    hit.transform.GetComponent<RawImage>().color = new Color(255, 0, 0);
                    hit.transform.GetComponent<TargetPracMove>().MoveTarget(10f);
                }
            }
            if (hit.transform.name == "I20M")
            {
                if (!(hit.transform.GetComponent<RawImage>().color == new Color(255, 0, 0)))
                {
                    hit.transform.GetComponent<RawImage>().color = new Color(255, 0, 0);
                    hit.transform.GetComponent<TargetPracMove>().MoveTarget(20f);
                }
            }
            if (hit.transform.name == "I40M")
            {
                if (!(hit.transform.GetComponent<RawImage>().color == new Color(255, 0, 0)))
                {
                    hit.transform.GetComponent<RawImage>().color = new Color(255, 0, 0);
                    hit.transform.GetComponent<TargetPracMove>().MoveTarget(40f);
                }
            }
            if (hit.transform.name == "IClear")
            {
                hit.transform.GetComponent<clear>().Clear();
            }
            if (hit.transform.name == "IEASY")
            {
                if (!(hit.transform.GetComponent<RawImage>().color == new Color(255, 0, 0)))
                {
                    hit.transform.GetComponent<RawImage>().color = new Color(255, 0, 0);

                    daThingy.Easy();

                }
            }
            if (hit.transform.name == "IMEDIUM")
            {
                if (!(hit.transform.GetComponent<RawImage>().color == new Color(255, 0, 0)))
                {
                    hit.transform.GetComponent<RawImage>().color = new Color(255, 0, 0);

                    daThingy.Mid();
                }
                
            }
            if (hit.transform.name == "IHARD")
            {
                if (!(hit.transform.GetComponent<RawImage>().color == new Color(255, 0, 0)))
                {
                    hit.transform.GetComponent<RawImage>().color = new Color(255, 0, 0);

                    daThingy.Hard();
                }
            }
            if (hit.transform.name == "IClearR")
            {
                hit.transform.GetComponent<clear>().Clear();
                daThingy.DisableAll();
            }
            if (hit.transform.name == "IClearH")
            {
                hit.transform.GetComponent<ClearH>().Clear();
            }
            if (hit.transform.name == "B-chest" && hit.transform.CompareTag("PracticeBot"))
            {
                torso.color = new Color(255, 0, 0);
            }
            if (hit.transform.name == "B-head" && hit.transform.CompareTag("PracticeBot"))
            {
                head.color = new Color(255, 0, 0);
            }
            if (hit.transform.name == "B-forearm_L" && hit.transform.CompareTag("PracticeBot"))
            {
                lHand.color = new Color(255, 0, 0);
            }
            if (hit.transform.name == "B-forearm_R" && hit.transform.CompareTag("PracticeBot"))
            {
                rHand.color = new Color(255, 0, 0);
            }
            if (hit.transform.name == "B-shin_L" && hit.transform.CompareTag("PracticeBot"))
            {
                lLeg.color = new Color(255, 0, 0);
            }
            if (hit.transform.name == "B-shin_R" && hit.transform.CompareTag("PracticeBot"))
            {
                rLeg.color = new Color(255, 0, 0);
            }
        }
        /*firing = false;
        gunAnim.SetBool("firing", firing);*/
        StartCoroutine(StopFiringAnim());
    }

    IEnumerator StopFiringAnim()
    {
        yield return new WaitForSeconds(.5f);
        firing = false;
        gunAnim.SetBool("firing", firing);
    }
}

