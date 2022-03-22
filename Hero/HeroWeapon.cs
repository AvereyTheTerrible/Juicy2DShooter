using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroWeapon : AgentWeapon
{
    [SerializeField]
    private UIAmmo uiAmmo = null;

    public bool AmmoFull { get => weapon && weapon.AmmoFull; }

    private void Start()
    {
        uiAmmo = FindObjectOfType<UIAmmo>();
        if (weapon)
        {
            weapon.OnAmmoChange.AddListener(uiAmmo.UpdateAmmoText);
            uiAmmo.UpdateAmmoText(weapon.Ammo);
        }
    }

    public void AddAmmo(int amount)
    {
        if (weapon)
            weapon.Ammo += amount;
    }
}
