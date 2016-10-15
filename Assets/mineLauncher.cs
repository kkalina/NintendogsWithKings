using UnityEngine;
using System.Collections;

public class mineLauncher : MonoBehaviour {

    public GameObject launchArm;
    public GameObject tireObj;
    public GameObject launcherObj;
    public GameObject mineObj;
    public GameObject muzzle;
    public float launchVel = 10f;

	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            launchArm.GetComponent<Animator>().SetTrigger("fire");
            launcherObj.GetComponent<Animator>().SetTrigger("fire");
            tireObj.GetComponent<spin>().speed = 35;
            GameObject mineInst = Instantiate(mineObj);
            mineInst.transform.position = muzzle.transform.position;
            mineInst.transform.rotation = muzzle.transform.rotation;
            mineInst.GetComponent<Rigidbody>().velocity = muzzle.transform.forward*launchVel;
        }
	
	}
}
