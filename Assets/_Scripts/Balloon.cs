using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour {
	public GameObject dropPrefab;
	GameObject drop;
	Vector3 pointA, pointB;
	private float secondsForOneLength = 2f;

	// Use this for initialization
	void Start () {
		Vector3 pos = gameObject.transform.localPosition;
		drop = Instantiate(dropPrefab, pos, Quaternion.identity) as GameObject;
		pointA = transform.position;
		pointB = new Vector3(pointA.x, pointA.y-1, pointA.z);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(pointA, pointB,
		  	Mathf.SmoothStep(0f,1f, Mathf.PingPong(Time.time/secondsForOneLength, 1f)));
		Vector3 newPosition = transform.localPosition;
		newPosition.y -= 2.5f;
		drop.transform.localPosition = newPosition;
	}

	void OnTriggerEnter(Collider coll) {
		DropObject();
	}

	void OnMouseDown(){
        // Testing
        //DropObject();
	} 

	void DropObject() {
		Destroy(drop);
		Vector3 pos = gameObject.transform.position;
		pos.y -= 2.5f;
		GameObject fallingObject = Instantiate(dropPrefab, pos, Quaternion.identity) as GameObject;
		Destroy(gameObject);
	}
}
