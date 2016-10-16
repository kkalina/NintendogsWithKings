using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

    private int event_num = 0;
    private TextMesh message;
   
	// Use this for initialization
	void Start () {
        message = GetComponentInChildren<TextMesh>();
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("here");
        event_num++;
        if(other.tag == "Dialogue")
            Destroy(other);
    }
    void Update() {
        switch (event_num) {
            case 1:
                message.text = "The King is in danger and needs your help";
                break;
            case 2:
                message.text = "Assassins have come to kill him, \n it is your job to keep him alive as long as possible";
                break;
            case 3:
                message.text = "Use Left Click to fire your weapon";
                break;
            case 4:
                message.text = "Switch weapons with 1, 2, and 3";
                break;
            case 5:
                message.text = "Protect the king but be careful not \n to destroy buildings or attack peasents";
                break;
            case 6:
                message.text = "Long live the king!";
                break;
            case 7:
                message.text = "Did I mention that as the royal bodyguard you don't take damage?";
                break;
            case 8:
                message.text = "If you are near the king, press E to call him towards you";
                break;
            case 9:
                message.text = "Assassins are Red, Peasents are white";
                break;
            case 10:
                message.text = "Step into the light if you are ready to fight";
                break;
            default:
                break;

        }
    }

}
