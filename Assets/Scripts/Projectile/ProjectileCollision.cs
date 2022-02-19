using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    [SerializeField] private GameObject impactParticles;

    private bool isColliding;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Bullet" && collision.gameObject.tag != ("Player") && !isColliding)
        {
            isColliding = true;

            var impact = Instantiate(impactParticles, collision.contacts[0].point, Quaternion.identity);
            Destroy(gameObject);
            Destroy(impact, 2);
        }
    }
}
