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
