using UnityEngine;
using System.Collections;

public class peasantDead : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject player = GameObject.Find("FPS_Player");
        player.GetComponent<FPSControl>().damage += 200;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
