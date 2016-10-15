using UnityEngine;
using System.Collections;

public class ThirdPersonController : MonoBehaviour {
	public float 	inH, inV;
	public float	rSpeed = 90; // Degrees per second
	public float	speed = 10; // Meters per second
    public float jumpForce = 10f;
	public Vector3	vel, angles;

	Rigidbody rigid;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody>();

    }

    void Update() {
        inH = Input.GetAxis("Horizontal");
        inV = Input.GetAxis("Vertical");
    }

    // Update is called once per frame
    void FixedUpdate () {

        angles = transform.rotation.eulerAngles;
		angles.y += inH * rSpeed * Time.fixedDeltaTime;
		transform.rotation = Quaternion.Euler(angles);

		//vel = rigid.velocity;
        vel = Vector3.zero;
        vel -= transform.forward * inV * speed;
        vel.y = rigid.velocity.y;

		rigid.velocity = vel;


	}
}
