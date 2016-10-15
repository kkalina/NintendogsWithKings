using UnityEngine;
using System.Collections;

public class spin : MonoBehaviour {

    public float idleSpeed = 1f;
    public float speed = 0f;
    private float angle = 0f;
    public float deceleration = .98f;

	// Use this for initialization
	void Start () {
        speed = idleSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        angle -= Time.deltaTime * speed;
        this.transform.localRotation = Quaternion.EulerAngles(0,angle,0);
	}

    void FixedUpdate()
    {
        if (speed > idleSpeed)
            speed = deceleration*speed;

    }
}
