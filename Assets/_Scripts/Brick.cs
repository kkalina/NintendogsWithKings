using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    private float startTime = 0f;
    private bool broken = false;
    private GameObject playerObj;
    private FPSControl playerController;
    //public GameObject brickDebris;
    public GameObject peasantDead;
    public GameObject messageAnchor;

    void Start()
    {
        startTime = Time.time;
        playerObj = GameObject.Find("FPS_Player");
        playerController = playerObj.GetComponent<FPSControl>();
        if(this.gameObject.GetComponent<Rigidbody>()!=null)
            this.gameObject.GetComponent<Rigidbody>().Sleep();
        messageAnchor = GameObject.Find("MessageAnchor");
    }

	void OnCollisionEnter(Collision Other)
    {
        if((Other.gameObject.tag == "Ground")&&(Time.time>startTime+5f)&&(!broken))
        {
            //Debug.Log("-$100!");
            playerController.damage += 100;
            /*GameObject brickDebrisInst = Instantiate(brickDebris);
            brickDebrisInst.transform.position = this.transform.position;
            brickDebrisInst.transform.rotation = this.transform.rotation;*/
            //Destroy(this.gameObject);
            broken = true;
            if(this.gameObject.GetComponent<Rigidbody>()!=null)
            this.gameObject.GetComponent<Rigidbody>().Sleep();
        }

        if (Other.gameObject.tag == "Peasant")
        {
            if ((this.gameObject.GetComponent<Rigidbody>().velocity.x > 2) || (this.gameObject.GetComponent<Rigidbody>().velocity.y > 2) || (this.gameObject.GetComponent<Rigidbody>().velocity.z > 2))
            {
                GameObject deadPeasantInst = Instantiate(peasantDead);
                deadPeasantInst.transform.position = Other.gameObject.transform.position;
                deadPeasantInst.transform.rotation = Other.gameObject.transform.rotation;
                //Rigidbody rigidPeasant = deadPeasantInst.GetComponent<Rigidbody>();
                //Rigidbody[] deadPeasantRigidbodies;
                //deadPeasantRigidbodies = deadPeasantInst.GetComponentsInChildren<Rigidbody>();
                //foreach (Rigidbody deadRigid in deadPeasantRigidbodies)
                //{
                //    deadRigid.AddForce(this.gameObject.GetComponent<Rigidbody>().velocity * peasantHitForce);
                //}
                if (!Other.gameObject.GetComponent<peasantController>().Assassin)
                {
                    messageAnchor.GetComponent<messageCenter>().createMessage("Peasant killed.");
                    playerObj.GetComponent<FPSControl>().damage += 500;
                }
                else
                {
                    messageAnchor.GetComponent<messageCenter>().createMessage("Assassin killed.");
                    playerObj.GetComponent<FPSControl>().damage -= 500;
                }

                Destroy(Other.gameObject);
            }
        }
    }
}
