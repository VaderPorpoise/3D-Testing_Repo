using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Gun_Revolver : GunBluePrint
{

    // Start is called before the first frame update
    void Start()
    {
        // set the weapon stats

        bulletSpeed = 25f;
        bulletDamage = 15;
        setUpWeapon();
        weaponsManager.OnShoot += WeaponsManager_OnShoot;
    }

    private void WeaponsManager_OnShoot(object sender, EventArgs e)
    {
        shootWeaponProjectile(WeaponTag, shootPointTrans.position, shootPointTrans.rotation);
    }


    // Update is called once per frame
    void Update()
    {
        //mouseLook.XRot;
        DebugRay(20);
    }

    void rotateTowardsCursor()
    {

    }


}
