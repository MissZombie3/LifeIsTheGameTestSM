using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePusher : MonoBehaviour
{
    [SerializeField] private float pushRadius = 2f;
    [SerializeField] private float pushForce = 2f;
    [SerializeField] private int maxBounces = 3;
    [SerializeField] private GameObject impactParticles;

    private int bounces = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Bullet" && collision.gameObject.tag != ("Player") && bounces <= maxBounces)
        {
            bounces++;

            Collider[] colliders = Physics.OverlapSphere(transform.position, pushRadius);
            foreach (Collider col in colliders)
            {
                if (col.tag == "Bullet")
                    continue;

                if (col.attachedRigidbody != null)
                {
                    Vector3 direction = col.transform.position - transform.position;
                    col.attachedRigidbody.AddForce(direction.normalized * pushForce);
                }
            }

            var impact = Instantiate(impactParticles, collision.contacts[0].point, Quaternion.identity);
            Destroy(impact, 2);
        }

        if (bounces == maxBounces)
            Destroy(gameObject);

    }
}
