using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform), typeof(GameObject), typeof(string))]
[System.Serializable]
public class GunBluePrint : MonoBehaviour
{
    [Header("weaponStats")]

    public static int numWeapons;

    public string WeaponTag;
    protected bool isGun = true;
    protected float bulletSpeed = 10f;
    protected int bulletDamage = 10;
    protected float fireRate;
    float knockBack = 100f;

    [Header("weapon Components")]
    public GameObject bulletPrefab;
    public GameObject BulletPoolObject;
    public Transform shootPointTrans;



    protected mouseLook mouseLook;

    protected GameObject playerObject;



    [HideInInspector]
    public PlayerWeaponsManager weaponsManager;

    //caching the bulletpooler
    BulletPooling bulletPooler;//not used yet **checkup on it
    protected void setUpWeapon()
    {
        weaponsManager = FindObjectOfType<PlayerWeaponsManager>();
        mouseLook = FindObjectOfType<mouseLook>();
        playerObject = weaponsManager.gameObject;


        bulletPooler = BulletPooling.Instance;
    }

    protected void shootWeaponProjectile(string bulletTag, Vector3 BulletPosition, Quaternion BulletRotation)
    {
        GameObject bullet = bulletPooler.SpawnFromPool(bulletTag, BulletPosition, BulletRotation);





        bullet.GetComponent<Rigidbody>().AddForce(transform.right.normalized * bulletSpeed, ForceMode.Impulse);
        bullet.GetComponent<bullet>().Damage = bulletDamage;
        applyKnockBack();
    }
    protected void applyKnockBack()
    {
        weaponsManager.knockBackPart.AddForce(-knockBack * weaponsManager.knockBackPart.transform.up, ForceMode.Impulse);

    }
    protected void DebugRay(float distance)
    {
        Debug.DrawRay(shootPointTrans.position, transform.right * distance, Color.red);
    }
    public void shootWeaponRaycast()
    {








    }

}

