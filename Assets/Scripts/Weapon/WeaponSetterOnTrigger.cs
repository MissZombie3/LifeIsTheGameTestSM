using UnityEngine;

public class WeaponSetterOnTrigger : MonoBehaviour
{
    [SerializeField] private WeaponType weaponType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            other.GetComponent<WeaponController>().SetWeapon(weaponType);
    }
}