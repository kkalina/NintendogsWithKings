using UnityEngine;
using System.Collections;

public class hammerCollider : MonoBehaviour
{
    public float peasantHitForce = 100f;
    public float brickHitForce = 100f;
    public GameObject peasantDead;
    public float awakeTime = 0f;
    public float duration = 0.2f;
    public GameObject sound;

    void Awake()
    {
        awakeTime = Time.time;
    }

    void FixedUpdate()
    {
        if (Time.time > (awakeTime + duration))
        {
            this.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Peasant")
        {
            Instantiate(sound);

            GameObject deadPeasantInst = Instantiate(peasantDead);
            deadPeasantInst.transform.position = other.gameObject.transform.position;
            deadPeasantInst.transform.rotation = other.gameObject.transform.rotation;
            //Rigidbody rigidPeasant = deadPeasantInst.GetComponent<Rigidbody>();
            Rigidbody[] deadPeasantRigidbodies;
            deadPeasantRigidbodies = deadPeasantInst.GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody deadRigid in deadPeasantRigidbodies)
            {
                deadRigid.AddForce(this.transform.forward * peasantHitForce);
            }
            Destroy(other.gameObject);
        }else if(other.gameObject.tag == "Brick") {
            Instantiate(sound);
            other.gameObject.GetComponent<Rigidbody>().AddForce(this.transform.forward * brickHitForce);
        }/*else
        {
            Instantiate(sound);  
            Rigidbody[] otherRigidbodies;
            otherRigidbodies = other.GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody otherRigid in otherRigidbodies)
            {
                otherRigid.AddForce(this.transform.forward * peasantHitForce);
            }
        }*/
    }
}
