using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public float force = 100f;
    //public float rad = 3f;
    public int lifetime = 4;
    private Rigidbody rb;
    // Use this for initialization
    public GameObject crater;
    public GameObject ricochetObj;
    public GameObject peasantDead;
    public GameObject vaseDebris;
    public float peasantHitForce = 100f;
    public float kingHitForce = 100f;
    public GameObject peasantKillMessage;
    public GameObject assassinKillMessage;
    public GameObject playerObj;
    public GameObject messageAnchor;


    void Start () {
        Destroy(this.gameObject, lifetime);
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * force);
        //rb.AddExplosionForce(force, transform.position + new Vector3 (10, 0, 0 ), rad);
        playerObj = GameObject.Find("FPS_Player");
        messageAnchor = GameObject.Find("MessageAnchor");
    }

    void OnCollisionEnter(Collision other) {
        //other.GetComponent<Rigidbody>().AddExplosionForce(50f, transform.position, 10f);
        if(other.rigidbody != null)
        {
            //other.rigidbody.AddRelativeForce(new Vector3(Random.Range(-100f, 100f), Random.Range(-100f, 100f),
            //    Random.Range(-100f, 100f)), ForceMode.Impulse);

        }
        if (other.gameObject.tag == "Wall")
        {
            ContactPoint contact = other.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;

            GameObject craterInst = Instantiate(crater);
            craterInst.transform.rotation = rot;
            pos += craterInst.transform.up * 0.1f;
            craterInst.transform.position = pos;
            craterInst.transform.SetParent(other.gameObject.transform);
            Instantiate(ricochetObj);
            //this.gameObject.GetComponent<AudioSource>().Play();
        }
        if(other.gameObject.tag == "Peasant")
        {

            GameObject deadPeasantInst = Instantiate(peasantDead);
            deadPeasantInst.transform.position = other.gameObject.transform.position;
            deadPeasantInst.transform.rotation = other.gameObject.transform.rotation;
            //Rigidbody rigidPeasant = deadPeasantInst.GetComponent<Rigidbody>();
            Rigidbody[] deadPeasantRigidbodies;
            deadPeasantRigidbodies = deadPeasantInst.GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody deadRigid in deadPeasantRigidbodies)
            {
                deadRigid.AddForce(this.gameObject.GetComponent<Rigidbody>().velocity*peasantHitForce);
            }

            if (!other.gameObject.GetComponent<peasantController>().Assassin)
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

            Destroy(other.gameObject);
        }
        else
                if (other.gameObject.tag == "Vase")
        {
            GameObject vaseDebrisInst = Instantiate(vaseDebris);
            vaseDebrisInst.transform.position = other.gameObject.transform.position;
            vaseDebrisInst.transform.rotation = other.gameObject.transform.rotation;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "King")
        {
            other.gameObject.GetComponent<KingNav>().health -= 99;
            other.gameObject.GetComponent<Rigidbody>().AddForce(this.transform.forward * kingHitForce);
        }
    }

}
