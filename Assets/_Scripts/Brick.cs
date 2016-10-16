using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    private float startTime = 0f;
    private bool broken = false;
    private GameObject playerObj;
    private FPSControl playerController;
    //public GameObject brickDebris;

    void Start()
    {
        startTime = Time.time;
        playerObj = GameObject.Find("FPS_Player");
        playerController = playerObj.GetComponent<FPSControl>();
        this.gameObject.GetComponent<Rigidbody>().Sleep();
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
            this.gameObject.GetComponent<Rigidbody>().Sleep();
        }
    }
}
