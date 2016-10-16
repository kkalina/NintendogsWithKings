using UnityEngine;
using System.Collections;

public class title : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Application.LoadLevel("Karls_Kastle_Test");
        }else if (Input.GetKeyDown(KeyCode.T))
        {

            Application.LoadLevel("Tutorial");
        }
	}
}
