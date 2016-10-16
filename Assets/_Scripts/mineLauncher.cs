using UnityEngine;
using System.Collections;

public class mineLauncher : MonoBehaviour {

    public GameObject launchArm;
    public GameObject tireObj;
    public GameObject launcherObj;
    public GameObject mineObj;
    public GameObject muzzle;
    public GameObject sound;
    public GameObject king;
    public float launchVel = 10f;
    public float ROF = 1;
    private float lastFireTime = -1f;

    void Start()
    {
        king = GameObject.Find("King");
    }

	void Update () {

        if (Input.GetMouseButtonDown(0)&&(Time.time > lastFireTime+ROF))
        {
            Instantiate(sound);
            launchArm.GetComponent<Animator>().SetTrigger("fire");
            launcherObj.GetComponent<Animator>().SetTrigger("fire");
            tireObj.GetComponent<spin>().speed = 35;
            GameObject mineInst = Instantiate(mineObj);
            //mineInst.GetComponent<LandmineKarl>().king = king;
            mineInst.transform.position = muzzle.transform.position;
            mineInst.transform.rotation = muzzle.transform.rotation;
            mineInst.GetComponent<Rigidbody>().velocity = muzzle.transform.forward*launchVel;
            lastFireTime = Time.time;
        }
	
	}
}
