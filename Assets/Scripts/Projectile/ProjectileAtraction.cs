using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAtraction : MonoBehaviour
{
    [SerializeField] private float attractionRadius = 2f;
    [SerializeField] private float attractionForce = 2f;
    [SerializeField] private float orbitSpeed = 20f;

    private Rigidbody rigidbody;
    private bool isColliding;
    private List<Rigidbody> rigidbodies = new List<Rigidbody>();

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //create an imaginary sphere on the projectile position.
        Collider[] colliders = Physics.OverlapSphere(transform.position, attractionRadius);
        foreach (Collider col in colliders)
        {
            if (col.tag == "Bullet")
                continue;

            if (col.attachedRigidbody != null && col.attachedRigidbody.useGravity && !rigidbodies.Contains(col.attachedRigidbody))
                rigidbodies.Add(col.attachedRigidbody);
        }

        foreach (Rigidbody rBody in rigidbodies)
        {
            if (rBody == null)
                continue;

            rBody.useGravity = false;
            rBody.transform.RotateAround(transform.position, Vector3.up, orbitSpeed * Time.deltaTime);
            if(Vector3.Distance(transform.position, rBody.transform.position) > 1)
            {
                Vector3 direction = transform.position - rBody.transform.position;
                rBody.AddForce(direction.normalized * attractionForce);
            }
        }
    }
    private void OnDestroy()
    {
        foreach (Rigidbody rBody in rigidbodies)
        {
            if (rBody == null)
                continue;
            rBody.useGravity = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Bullet" && collision.gameObject.tag != ("Player") && !isColliding)
        {
            isColliding = true;
            rigidbody.isKinematic = true;
            Destroy(gameObject, 2f);
        }
    }
}
