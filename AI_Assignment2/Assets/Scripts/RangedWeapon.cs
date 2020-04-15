using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    // Characteristics
    [SerializeField] private string weaponName;
    [SerializeField] private int currentAmmo;
    [SerializeField] private int totalAmmo;
    [SerializeField] private int magazineSize;
    [SerializeField] private int ammoCapacity;
    [SerializeField] private float baseDamage;

    [SerializeField] Transform shootPosition;
    [SerializeField] Vector3 shootDirection;

    // Initializing the base properties of the weapon
    public void InitGun(string name, int cAmmo, int tAmmo, int magSize, int ammoCap, float baseDmg)
    {
        weaponName = name;
        currentAmmo = cAmmo;
        totalAmmo = tAmmo;
        magazineSize = magSize;
        ammoCapacity = ammoCap;
        baseDamage = baseDmg;
        shootDirection = shootPosition.forward;
    }

    public void FireGun()
    {
        HitScanBullet.ShootHitScan(shootPosition.position, shootDirection);
        currentAmmo -= 1;
    }
}
