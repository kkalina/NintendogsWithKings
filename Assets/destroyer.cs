using UnityEngine;
using System.Collections;

public class destroyer : MonoBehaviour {

    public float lifetime = 1f;
    private float awakeTime = 0f;

	void Start () {
        awakeTime = Time.time;
	}
	
	void FixedUpdate () {
        if (Time.time > awakeTime + lifetime) {
            Destroy(this.gameObject);
        }
            
	}
}
