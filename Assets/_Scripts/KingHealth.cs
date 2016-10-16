using UnityEngine;
using System.Collections;

public class KingHealth : MonoBehaviour {
    private TextMesh healthDisplay;
    private GameObject playerObj;
    private FPSControl playerController;
    GameObject king;
    public float health;

	// Use this for initialization
	void Start () {
        playerObj = GameObject.Find("FPS_Player");
        playerController = playerObj.GetComponent<FPSControl>();
        king = playerController.King;
        health = king.GetComponent<KingNav>().health;
        healthDisplay = this.gameObject.GetComponent<TextMesh>();
        healthDisplay.text = health.ToString("F2");
    }
	
	// Update is called once per frame
	void Update ()
    {
    	if (king == null) {
    		king = playerController.King;
    	}
        health = king.GetComponent<KingNav>().health;
        healthDisplay.text = health.ToString("F2");
	}
}
