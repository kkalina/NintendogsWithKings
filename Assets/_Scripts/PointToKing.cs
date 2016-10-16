using UnityEngine;
using System.Collections;

public class PointToKing : MonoBehaviour {

    public Transform arrow;
    public Transform king;
    public Transform player;

    private Vector3 ray;
    private RaycastHit hit;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if(Physics.Raycast(player.position, king.position, out hit)){
            float angle = Mathf.Atan2(hit.point.y, hit.point.x) * Mathf.Rad2Deg;
            arrow.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
	}
}
