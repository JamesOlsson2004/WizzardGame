using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveTestBall : MonoBehaviour
{
    [Header("Stats")]
    public float radius = 5.0F;
    public float power = 10.0F;
    public float timer = 5f;
    public float Power = 5f;

    [Header("Component Grab List")]
    public Rigidbody rb;
    public GameObject body;
    public GameObject This;
    public SphereCollider SC;

    void Update()
    {
        rb.AddForce(transform.forward * (Power) * Time.deltaTime, ForceMode.Force);
        Power -= 2.5f * Time.deltaTime;

        if (Power <= 0)
        {
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    Transform parentObject = rb.GetComponentInParent<Transform>();
                    var ExplosionDir = (transform.position - parentObject.position).magnitude;
                    rb.AddExplosionForce(power, explosionPos, radius, 3.0F, ForceMode.Impulse);
                }
            }

            Destroy(body);
            Destroy(This);
        }
    }

    
}
