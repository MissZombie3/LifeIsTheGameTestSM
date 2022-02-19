using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private TextMeshProUGUI weaponTypeText;
    [SerializeField] private List<WeaponReference> weapons = new List<WeaponReference>();

    private WeaponReference currentWeapon;
    private float nextShoot = -1;

    private void Awake()
    {
        HideAllWeapons();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        if(currentWeapon == null)
            return;

        if (Input.GetButtonDown("Fire1") && Time.time >= nextShoot)
        {
            nextShoot = Time.time + currentWeapon.config.FireRate;
            InstantiateProjectile();
        }
    }

    private void InstantiateProjectile()
    {
        if (currentWeapon == null)
            return;

        Rigidbody proyectileObj = Instantiate(currentWeapon.config.Projectile, currentWeapon.firePoint.position, Quaternion.identity);
        proyectileObj.velocity = cam.transform.forward * currentWeapon.config.ProjectileSpeed;
    }

    public void SetWeapon(WeaponType type)
    {
        currentWeapon = weapons.Find(w => w.type == type);
        HideAllWeapons();

        if (currentWeapon != null)
        {
            currentWeapon.model.SetActive(true);
            weaponTypeText.text = type.ToString();
        }
    }

    private void HideAllWeapons()
    {
        foreach (WeaponReference weapon in weapons)
        {
            weapon.model.SetActive(false);
        }
    }
}
