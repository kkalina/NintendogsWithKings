using UnityEngine;
using System.Collections;
using DG.Tweening;


public class Shoot : MonoBehaviour {
    public GameObject bullet;
    public Transform fire_point;
    bool shooting = false;

    void Start() {
       // fire_point = transform.FindChild("Fire_Point").transform;
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && !shooting) {
            StartCoroutine(shoot());
        }
	}

    IEnumerator shoot() {
        shooting = true;
        Instantiate(bullet, fire_point.position + fire_point.forward * 1.5f, fire_point.rotation);
        this.transform.DOShakeScale(.4f, new Vector3(0, 0, 2f), 10, 1, true);
        this.transform.DOPunchRotation(new Vector3(90f, 10f, 10f), .4f, 1, .1f);
        this.transform.DOPunchPosition(new Vector3(0f, 0f, -.8f), .4f, 1, 1, false);
        yield return new WaitForSeconds(.5f);
        shooting = false;
    }
}
