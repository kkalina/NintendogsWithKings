using UnityEngine;
using System.Collections;

public class FPSControl : MonoBehaviour {
	Transform camTrans;

	public float	vertMult=0.5f, vertMin=-30, vertMax=30;
	public float	horizMult=0.5f;
	public float	speed = 10;
	
	public Vector3 	rot;
	public Vector3 	camRot;
	Rigidbody 		rigid;

	// Use this for initialization
	void Start () {
		camTrans = transform.Find ("Camera");
		rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		rot = transform.localRotation.eulerAngles;
		camRot = camTrans.localRotation.eulerAngles;
		if (camRot.x > 180) camRot.x -= 360;
		
		float mDeltaX = Input.GetAxis("Mouse X");
		float mDeltaY = Input.GetAxis("Mouse Y");

		print ("mX:"+mDeltaX+"    mY:"+mDeltaY);

		camRot.x -= mDeltaY * vertMult;
		camRot.x = Mathf.Clamp(camRot.x, vertMin, vertMax);

		rot.y += mDeltaX * horizMult;

		transform.localRotation = Quaternion.Euler(rot);
		camTrans.localRotation = Quaternion.Euler(camRot);
	}

	void FixedUpdate() {
		float vX = Input.GetAxis("Horizontal");
		float vY = Input.GetAxis("Vertical");

		Vector3 vel = Vector3.zero;
		vel += transform.forward * vY;
		vel += transform.right * vX;
		vel *= speed;
		vel.y = rigid.velocity.y;

		rigid.velocity = vel;
	}
}
