using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentWeapon : MonoBehaviour
{
    private float targetAngle;

    [SerializeField]
    private WeaponRenderer weaponRenderer;
    [SerializeField]
    protected Weapon weapon;

    private void Awake()
    {
        AssignWeapon();
    }

    private void AssignWeapon()
    {
        weaponRenderer = GetComponentInChildren<WeaponRenderer>();
        weapon = GetComponentInChildren<Weapon>();
    }

    public virtual void AimWeapon(Vector2 aimTarget)
    {
        var aimDirection = (Vector3)aimTarget - transform.position;
        targetAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        RenderWeapon();
        transform.rotation = Quaternion.AngleAxis(targetAngle, Vector3.forward);
    }

    private void RenderWeapon()
    {
        if (!weaponRenderer)
            return;

        weaponRenderer.FlipSprite(targetAngle > 90 || targetAngle < -90);
        weaponRenderer.RenderBehindHead(targetAngle < 180 && targetAngle > 0);
    }

    public void Shoot()
    {
        if (!weapon)
            return;
        weapon.TryShooting();
    }

    public void StopShooting()
    {
        if (!weapon)
            return;
        weapon.StopShooting();
    }
}