using UnityEngine;
using System.Collections;

public class scrollMessage : MonoBehaviour {

    public float speed = 1f;

	void Update () {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - speed, this.transform.position.z);
	}
}
