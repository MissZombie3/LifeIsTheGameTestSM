using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Create Weapon")]    
public class WeaponConfig : ScriptableObject
{
    [SerializeField] private Rigidbody projectile;
    [SerializeField] private float projectileSpeed = 30;
    [SerializeField] private float fireRate = 4;

    public Rigidbody Projectile => projectile; 
    public float ProjectileSpeed => projectileSpeed;
    public float FireRate => fireRate;
}