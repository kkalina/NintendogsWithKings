using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UnitySampleAssets.Effects
{
    public class ExplosionPhysicsForceCustom : MonoBehaviour
    {

        public GameObject peasantDead;
        public GameObject vaseDebris;

        public float explosionForce = 4;

        private IEnumerator Start()
        {
            // wait one frame because some explosions instantiate debris which should then
            // be pushed by physics force
            yield return null;

            float multiplier = GetComponent<ParticleSystemMultiplier>().multiplier;

            float r = 10*multiplier;
            Collider[] cols = Physics.OverlapSphere(transform.position, r);
            List<Rigidbody> rigidbodies = new List<Rigidbody>();
            foreach (var col in cols)
            {
                if (col.attachedRigidbody != null && !rigidbodies.Contains(col.attachedRigidbody))
                {
                    rigidbodies.Add(col.attachedRigidbody);
                }
                if(col.gameObject.tag == "Peasant")
                {
                    //Debug.Log("Peasant Blown Up!");
                    GameObject deadPeasantInst = Instantiate(peasantDead);
                    deadPeasantInst.transform.position = col.gameObject.transform.position;
                    deadPeasantInst.transform.rotation = col.gameObject.transform.rotation;
                    //Rigidbody rigidPeasant = deadPeasantInst.GetComponent<Rigidbody>();
                    Rigidbody[] deadPeasantRigidbodies;
                    deadPeasantRigidbodies = deadPeasantInst.GetComponentsInChildren<Rigidbody>(); 
                    foreach (Rigidbody deadRigid in deadPeasantRigidbodies)
                    {
                        if ((deadRigid != null)&&(!rigidbodies.Contains(deadRigid)))
                            rigidbodies.Add(deadRigid);
                    }
                    Destroy(col.gameObject);
                }else
                if (col.gameObject.tag == "Vase")
                {
                    GameObject vaseDebrisInst = Instantiate(vaseDebris);
                    vaseDebrisInst.transform.position = col.gameObject.transform.position;
                    vaseDebrisInst.transform.rotation = col.gameObject.transform.rotation;
                    Destroy(col.gameObject);
                }
            }
            foreach (var rb in rigidbodies)
            {
                rb.AddExplosionForce(explosionForce*multiplier, transform.position, r, 1*multiplier, ForceMode.Impulse);
            }
        }
    }
}