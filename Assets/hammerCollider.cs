using UnityEngine;
using System.Collections;

public class hammerCollider : MonoBehaviour
{
    public float peasantHitForce = 100f;
    public float brickHitForce = 100f;
    public float kingHitForce = 100f;
    public GameObject peasantDead;
    public float awakeTime = 0f;
    public float duration = 0.2f;
    public GameObject sound;
    public GameObject peasantKillMessage;
    public GameObject assassinKillMessage;
    public GameObject playerObj;
    public GameObject messageAnchor;

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


            if (!other.gameObject.GetComponent<peasantController>().Assassin)
            {
                GameObject PKMI = Instantiate(peasantKillMessage);
                PKMI.transform.position = messageAnchor.transform.position;
                PKMI.transform.rotation = messageAnchor.transform.rotation;
                PKMI.transform.SetParent(messageAnchor.gameObject.transform);
                playerObj.GetComponent<FPSControl>().damage += 500;
            }
            else
            {
                GameObject AKMI = Instantiate(assassinKillMessage);
                AKMI.transform.position = messageAnchor.transform.position;
                AKMI.transform.rotation = messageAnchor.transform.rotation;
                AKMI.transform.SetParent(messageAnchor.gameObject.transform);
                playerObj.GetComponent<FPSControl>().damage -= 500;
            }

            Destroy(other.gameObject);
        }else if(other.gameObject.tag == "Brick") {
            Instantiate(sound);
            other.gameObject.GetComponent<Rigidbody>().AddForce(this.transform.forward * brickHitForce);
        }
        else if (other.gameObject.tag == "King")
        {
            Instantiate(sound);
            other.gameObject.GetComponent<KingNav>().health-=50;
            other.gameObject.GetComponent<Rigidbody>().AddForce(this.transform.forward * kingHitForce);
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
