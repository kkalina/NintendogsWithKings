using UnityEngine;
using System.Collections;

public class mineLauncher : MonoBehaviour {

    public GameObject launchArm;
    public GameObject tireObj;
    public GameObject launcherObj;

	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            launchArm.GetComponent<Animator>().SetTrigger("fire");
            launcherObj.GetComponent<Animator>().SetTrigger("fire");
            tireObj.GetComponent<spin>().speed = 35;
        }
	
	}
}
