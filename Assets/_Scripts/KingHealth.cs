using UnityEngine;
using System.Collections;

public class KingHealth : MonoBehaviour {
    private TextMesh healthDisplay;
    private GameObject playerObj;
    private FPSControl playerController;
    GameObject king;
    public float health;
    float maxHealth;

	// Use this for initialization
	void Start () {
        playerObj = GameObject.Find("FPS_Player");
        playerController = playerObj.GetComponent<FPSControl>();
        king = playerController.King;
        health = king.GetComponent<KingNav>().health;
        maxHealth = health;
        healthDisplay = gameObject.GetComponent<TextMesh>();
        healthDisplay.text = health.ToString("F0") + "/" + maxHealth.ToString("F0");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (health != king.GetComponent<KingNav>().health) {
            health = king.GetComponent<KingNav>().health;
	    	healthDisplay.text = health.ToString("F0") + "/" + maxHealth.ToString("F0");
	    }
	}
}
