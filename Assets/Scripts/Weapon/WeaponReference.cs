using UnityEngine;

[System.Serializable]
public class WeaponReference
{
    public WeaponType type;
    public Transform firePoint;
    public GameObject model;
    public WeaponConfig config;
}
