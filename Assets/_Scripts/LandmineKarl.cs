using UnityEngine;
using System.Collections;

public class LandmineKarl : MonoBehaviour
{

    public GameObject parentObj;
    public GameObject explosion;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag != "Landmine")
        {
            GameObject explosionInst = Instantiate(explosion);
            explosionInst.transform.position = parentObj.transform.position;
            Destroy(parentObj);
        }
    }
}
