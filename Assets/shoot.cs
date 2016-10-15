using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {
    public GameObject bullet;

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(bullet, transform.position+ new Vector3(1, 0, 0) , transform.rotation);
        }
	}
}
