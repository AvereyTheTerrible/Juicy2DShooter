using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private Transform muzzle;
    
    private int ammo = 10;

    [field: SerializeField]
    public SOWeaponData WeaponData { get; set; }

    public int Ammo
    {
        get { return ammo; }
        set {
            ammo = Mathf.Clamp(value, 0, WeaponData.AmmoCapacity);
            OnAmmoChange?.Invoke(ammo);
        }
    }

    public bool AmmoFull { get => Ammo >= WeaponData.AmmoCapacity; }

    [SerializeField]
    private int startingAmmoAmount = 100;

    private bool isShooting = false;

    [SerializeField]
    private bool reloadCoroutine = false;

    [field: SerializeField]
    public UnityEvent OnShoot { get; set; }

    [field: SerializeField]
    public UnityEvent OnShootNoAmmo { get; set; }

    [field: SerializeField]
    public UnityEvent<int> OnAmmoChange { get; set; }


    private void Start()
    {
        Ammo = startingAmmoAmount;
    }

    public void TryShooting()
    {
        isShooting = true;
    }

    public void StopShooting()
    {
        isShooting = false;   
    }

    public void ReloadAmmo(int ammoAmountToAdd)
    {
        Ammo += ammoAmountToAdd;
    }

    private void Update()
    {
        UseWeapon();
    }

    private void UseWeapon()
    {
        if (isShooting && !reloadCoroutine)
        {
            if (Ammo > 0)
            {
                Ammo--;
                OnShoot?.Invoke();
                for (int i = 0; i < WeaponData.GetBulletCountToSpawn(); i++)
                {
                    ShootBullet();
                }
            }
            else
            {
                isShooting = false;
                OnShootNoAmmo?.Invoke();
                return;
            }

            FinishShooting();
        }
    }

    private void FinishShooting()
    {
        StartCoroutine(DelayNextShot());
        if (WeaponData.WeaponType == WeaponType.semiAutomatic)
        {
            isShooting = false;
        }

        else if (WeaponData.WeaponType == WeaponType.automatic)
        {
            isShooting = true;
        }
    }

    private IEnumerator DelayNextShot()
    {
        reloadCoroutine = true;
        yield return new WaitForSecondsRealtime(WeaponData.WeaponDelay);
        reloadCoroutine = false;
    }

    private void ShootBullet()
    {
        SpawnBullet(muzzle.position, CalculateAngle(muzzle));
    }

    private void SpawnBullet(Vector3 position, Quaternion rotation)
    {
        var bulletInstance = Instantiate(WeaponData.BulletData.BulletPrefab, position, rotation);
        bulletInstance.GetComponent<Bullet>().BulletData = WeaponData.BulletData;
    }

    private Quaternion CalculateAngle(Transform muzzle)
    {
        float spread = Random.Range(-WeaponData.SpreadAngle, WeaponData.SpreadAngle);
        Quaternion bulletSpreadRotation = Quaternion.Euler(new Vector3(0, 0, spread));
        return muzzle.transform.rotation * bulletSpreadRotation;
    }
}
