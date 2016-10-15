using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour {
	public GameObject[] dropPrefab;
	GameObject drop;
	Vector3 pointA, pointB;
	private float secondsForOneLength = 2f;
	public float timer;
	int random;
	public AudioClip whistle;

	// Use this for initialization
	void Start () {
		random = Random.Range(0,3);
		Vector3 pos = transform.localPosition;
		pos.y -= 3f;
		drop = Instantiate(dropPrefab[random], pos, Quaternion.identity) as GameObject;
		pointA = transform.position;
		pointB = new Vector3(pointA.x, pointA.y-0.5f, pointA.z);
		timer = Random.Range(10f,180f);
	}
	
	// Update is called once per frame
	void Update () {
		// Bob the balloon
		transform.position = Vector3.Lerp(pointA, pointB,
		  	Mathf.SmoothStep(0f,1f, Mathf.PingPong(Time.time/secondsForOneLength, 1f)));

		// Attach the weight to the balloon
		Vector3 newPosition = transform.localPosition;
		newPosition.y -= 3;
		drop.transform.localPosition = newPosition;

		// Countdown timer for drop
		timer -= Time.deltaTime;
		if (timer < 0) {
			DropObject();
		}
	}

	void OnTriggerEnter(Collider coll) {
		DropObject();
	}

	void OnMouseDown() {
        // Testing
        DropObject();
	} 
	
	void DropObject() {
		Vector3 pos = transform.localPosition;
		pos.y -= 2.5f;
		Destroy(drop);
		GameObject fallingObject = Instantiate(dropPrefab[random], pos, Quaternion.identity) as GameObject;
		fallingObject.GetComponent<AudioSource>().Play();
		Destroy(gameObject);
	}
}
