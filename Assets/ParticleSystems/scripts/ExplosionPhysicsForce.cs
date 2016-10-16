using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UnitySampleAssets.Effects
{
    public class ExplosionPhysicsForce : MonoBehaviour
    {

        public float explosionForce = 4;

        private IEnumerator Start()
        {
            // wait one frame because some explosions instantiate debris which should then
            // be pushed by physics force
            yield return null;

            float r = 10f;
            Collider[] cols = Physics.OverlapSphere(transform.position, r);
            List<Rigidbody> rigidbodies = new List<Rigidbody>();
            foreach (var col in cols)
            {
                if (col.attachedRigidbody != null && !rigidbodies.Contains(col.attachedRigidbody))
                {
                    rigidbodies.Add(col.attachedRigidbody);
                }
            }
            foreach (var rb in rigidbodies)
            {
                rb.AddExplosionForce(explosionForce, transform.position, r, 1, ForceMode.Impulse);
            }
        }
    }
}