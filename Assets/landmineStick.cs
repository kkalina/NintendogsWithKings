using UnityEngine;
using System.Collections;

public class landmineStick : MonoBehaviour {

    private bool stuck = false;
    
    void OnCollisionEnter(Collision collision)
    {
        if (!stuck)
        {
            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            this.transform.rotation = rot;
            pos += this.transform.up*0.3f;
            this.transform.position = pos;
            this.transform.SetParent(collision.gameObject.transform);
            Destroy(this.gameObject.GetComponent<Rigidbody>());
            stuck = true;
        }
    }
    

}
