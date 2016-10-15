using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
    public GameObject bullet;
    public Transform fire_point;

    void Start() {
        fire_point = transform.FindChild("Fire_Point").transform;
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            Instantiate(bullet, fire_point.position + fire_point.forward*1.5f , fire_point.rotation);
        }
	}
}
