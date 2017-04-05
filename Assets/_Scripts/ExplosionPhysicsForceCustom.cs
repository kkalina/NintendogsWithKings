using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UnitySampleAssets.Effects
{
    public class ExplosionPhysicsForceCustom : MonoBehaviour
    {

        public GameObject peasantDead;
        public GameObject vaseDebris;
        public GameObject peasantKillMessage;
        public GameObject assassinKillMessage;
        public GameObject playerObj;
        public GameObject messageAnchor;

        public float explosionForce = 4;

        void Awake()
        {
            playerObj = GameObject.Find("FPS_Player");
            messageAnchor = GameObject.Find("MessageAnchor");
        }

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
                    if (!col.gameObject.GetComponent<peasantController>().Assassin)
                    {
                        //GameObject PKMI = Instantiate(peasantKillMessage);
                        //PKMI.transform.position = messageAnchor.transform.position;
                        //PKMI.transform.rotation = messageAnchor.transform.rotation;
                        //PKMI.transform.SetParent(messageAnchor.gameObject.transform);
                        messageAnchor.GetComponent<messageCenter>().createMessage("Peasant killed.");
                        playerObj.GetComponent<FPSControl>().damage += 500;
                    }
                    else
                    {
                        //GameObject AKMI = Instantiate(assassinKillMessage);
                        //AKMI.transform.position = messageAnchor.transform.position;
                        //AKMI.transform.rotation = messageAnchor.transform.rotation;
                        //AKMI.transform.SetParent(messageAnchor.gameObject.transform);
                        messageAnchor.GetComponent<messageCenter>().createMessage("Assassin killed.");
                        playerObj.GetComponent<FPSControl>().damage -= 500;
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
