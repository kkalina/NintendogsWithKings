using UnityEngine;
using System.Collections;

public class LandmineKarl : MonoBehaviour
{

    public GameObject parentObj;
    public GameObject explosion;
    private float startTime = 0f;
    public float armDelay = 2f;
    public bool armed = false;
    public GameObject light;
    public float blink = 1f;
    public float lastBlink = 0f;

    void Start()
    {
        startTime = Time.time;
    }

    void FixedUpdate()
    {
        if ((Time.time > (startTime + armDelay))&&(!armed))
        {
            armed = true;
            light.SetActive(true);
        }
        if (armed && (Time.time>(lastBlink+blink)))
        {
            if (light.active)
                light.SetActive(false);
            else
                light.SetActive(true);

            lastBlink = Time.time;
        }

    }

    void OnTriggerEnter(Collider coll)
    {
        if ((coll.gameObject.tag != "Landmine") && armed)
        {
            GameObject explosionInst = Instantiate(explosion);
            explosionInst.transform.position = parentObj.transform.position + parentObj.transform.up*0.5f;
            Destroy(parentObj);
        }
    }
}
