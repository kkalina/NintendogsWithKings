using UnityEngine;
using System.Collections;

public class Countdown : MonoBehaviour {
	public float countdown;
    private TextMesh timer;
    private GameObject playerObj;
    private FPSControl playerController;

	// Use this for initialization
	void Start () {
        playerObj = GameObject.Find("FPS_Player");
        playerController = playerObj.GetComponent<FPSControl>();
        timer = this.gameObject.GetComponent<TextMesh>();
        countdown = playerController.countdownToWin;
        timer.text = countdown.ToString("F2");
    }
	
	// Update is called once per frame
	void Update ()
    {
        countdown = playerController.countdownToWin;
        timer.text = countdown.ToString("F2");
	}
}
