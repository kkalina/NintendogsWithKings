using UnityEngine;
using System.Collections;

public class LandmineKarl : MonoBehaviour
{

    public GameObject parentObj;
    public GameObject explosion;
    private float startTime = 0f;
    public float armDelay = 2f;
    public bool armed = false;
    public GameObject lightObj;
    public float blink = 1f;
    public float lastBlink = 0f;
    public GameObject landmineBase;
    //public GameObject crater;

    void Start()
    {
        startTime = Time.time;
    }

    void FixedUpdate()
    {
        //if ((Time.time > (startTime + armDelay))&&(!armed))
        if(landmineBase.GetComponent<landmineStick>().stuck)
        {
            armed = true;
            lightObj.SetActive(true);
        }
        if (armed && (Time.time>(lastBlink+blink)))
        {
            if (lightObj.active)
                lightObj.SetActive(false);
            else
                lightObj.SetActive(true);

            lastBlink = Time.time;
        }

    }

    void OnTriggerEnter(Collider coll)
    {
        if ((coll.gameObject.tag != "Landmine") && armed)
        {
            GameObject explosionInst = Instantiate(explosion);
            explosionInst.transform.position = parentObj.transform.position + parentObj.transform.up*0.5f;
            //GameObject craterInst = Instantiate(crater);
            //crater.transform.position = this.transform.position;
            //crater.transform.rotation = this.transform.rotation;
            Destroy(parentObj);
        }
    }
}
