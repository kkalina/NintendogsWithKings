using UnityEngine;
using System.Collections;

public class Ragdoller : MonoBehaviour {

    public GameObject ragdoll;
    SkinnedMeshRenderer skin;

	// Use this for initialization
	void Start () {
        skin = transform.FindChild("Character").gameObject.GetComponent<SkinnedMeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1) && skin.enabled) {
            skin.enabled = false;
            Instantiate(ragdoll, transform.position, Quaternion.identity);
        }
    }
}
