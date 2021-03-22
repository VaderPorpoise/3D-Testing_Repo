using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerWeaponsManager : MonoBehaviour
{

    public MyAnimator TargetAnimator;
    public GameObject startingGun;
    public Transform GunStartingPoint;
    public Transform MeleeStartingPoint;

    public GunBluePrint[] currentGuns;
    public GunBluePrint[] currentMeleeWeapons;
    public int equipedWeaponID;

    public GameObject startingSword;
    public event EventHandler OnShoot;

    public Rigidbody knockBackPart;
    //  public class OnShootEventArgs : EventArgs { public int weaponID; }

    [HideInInspector]
    public bool hasGun = false;
    public bool hasSword = false;
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            
            SpawnStartingSword();
        } if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            SpawnStartingGun();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // OnShoot?.Invoke(this, new OnShootEventArgs { weaponID = equipedWeaponID });
            OnShoot?.Invoke(this, EventArgs.Empty);
        }
    }
    void SpawnStartingGun()
    {



        //startingGun = currentGuns[0].gameObject;
        GameObject gun = EquipWeapon(startingGun, true);
        gun.GetComponent<GunBluePrint>().weaponsManager = this;
        hasGun = true;


    }
    void SpawnStartingSword()
    {
        GameObject melee = EquipWeapon(startingSword, false);
        melee.GetComponent<MeleeBluePrint>().WeaponsManager = this;
        hasGun = true;
    }
    // Start is called before the first frame update
    void Start()
    {




    }
    void PickUpWeapon(int weaponID)
    {
    }


    GameObject EquipWeapon(GameObject weapon, bool isGun)
    {
        if (isGun)
        {
            GameObject gun = Instantiate(weapon, GunStartingPoint);
            return gun;
        }
        else
        {
            GameObject melee = Instantiate(weapon, MeleeStartingPoint);
            return melee;
        }

    }

    GameObject SwapWeapons(GameObject weapon)
    {

        GameObject gun = Instantiate(weapon, GunStartingPoint);
        return gun;
    }
    // Update is called once per frame

}

