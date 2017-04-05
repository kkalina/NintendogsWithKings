using UnityEngine;
using System.Collections;

public class levelController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("Karls_Intro");

        }
        else if (Input.GetKeyDown(KeyCode.F1))
        {
            Application.LoadLevel(Application.loadedLevelName); 
        }
	}
}
