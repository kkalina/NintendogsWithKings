using UnityEngine;
using System.Collections;

public class spin : MonoBehaviour {

    public float speed = 1f;
    private float angle = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        angle += Time.deltaTime * speed;
        this.transform.localRotation = Quaternion.EulerAngles(0,angle,0);
	}
}
