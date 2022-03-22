using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hero : MonoBehaviour, IAgent, IHittable
{

    private bool dead = false;

    [field: SerializeField]
    public UnityEvent OnDie { get; set; }
    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }
    [field: SerializeField]
    public UnityEvent OnHealthLow { get; set; }
    [SerializeField]
    private int maxHealth;

    private int health;

    public int Health
    {
        get => health;
        set
        {
            health = Mathf.Clamp(value, 0, maxHealth);
            UIHealth.UpdateUI(health);
        }
    }

    [field: SerializeField]
    public UIHealth UIHealth { get; set; }

    [field: SerializeField]
    public HeroWeapon HeroWeapon { get; private set; }

    private void Awake()
    {
        UIHealth = FindObjectOfType<UIHealth>();
        if (!HeroWeapon)
            HeroWeapon = GetComponentInChildren<HeroWeapon>();
    }


    private void Start()
    {
        Health = maxHealth;
        UIHealth.Initialize(Health);
    }

    public void GetHit(int damage, GameObject damageDealer)
    {
        if (!dead)
        {
            Health -= damage;
            if (Health >= 0)
                OnGetHit?.Invoke();
            if (Health <= 2)
                OnHealthLow?.Invoke();
            if (Health <= 0)
            {
                OnDie?.Invoke();
                dead = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Resource"))
        {
            var resource = collision.GetComponent<Resource>();
            if (resource)
            {
                switch (resource.ResourceData.ResourceType)
                {
                    case ResourceTypeEnum.Health:
                        if (Health >= maxHealth)
                            return;

                        Health += resource.ResourceData.GetAmount();
                        resource.PickUpResource();
                        break;
                    case ResourceTypeEnum.Ammo:
                        if (HeroWeapon.AmmoFull)
                            return;
                        HeroWeapon.AddAmmo(resource.ResourceData.GetAmount());
                        resource.PickUpResource();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}