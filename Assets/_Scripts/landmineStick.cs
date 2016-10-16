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
            GameObject attachPoint = new GameObject();
            attachPoint.transform.rotation = rot;
            pos += this.transform.up*0.3f;
            attachPoint.transform.position = pos;
            attachPoint.transform.SetParent(collision.gameObject.transform);
            attachPoint.transform.localScale = new Vector3(1, 1, 1);
            this.transform.position = attachPoint.transform.position;
            this.transform.rotation = attachPoint.transform.rotation;
            this.transform.SetParent(attachPoint.transform);
            Destroy(this.gameObject.GetComponent<Rigidbody>());
            this.gameObject.GetComponent<AudioSource>().Play();
            stuck = true;
        }
    }
    

}
