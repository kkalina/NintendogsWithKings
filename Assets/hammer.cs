using UnityEngine;
using System.Collections;

public class hammer : MonoBehaviour
{
    public float ROF = 2;
    public float impactDelay = .5f;
    private float lastFireTime = -1f;
    public GameObject sound;
    public GameObject colliderBox;
    public bool swinging = false;
    public bool activated = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if((Time.time > lastFireTime + ROF) && swinging)
        {
            swinging = false;
            activated = false;
            //colliderBox.SetActive(false);
        }
        else if ((Time.time > lastFireTime + impactDelay) && swinging && !activated)
        {
            colliderBox.SetActive(true);
            colliderBox.GetComponent<hammerCollider>().awakeTime = Time.time;
            activated = true;
        }
            if (Input.GetMouseButtonDown(0) && !swinging)
        {
            Instantiate(sound);
            this.gameObject.GetComponent<Animator>().SetTrigger("swing");
            lastFireTime = Time.time;
            swinging = true;
        }
    }
}
