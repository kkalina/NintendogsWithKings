using UnityEngine;
using System.Collections;

public class Weight : MonoBehaviour {
	public AudioClip impact;
	bool collision = false;
	public GameObject dustGO;

	void OnCollisionEnter(Collision col) {
		HitGround(col);
	}

	public void HitGround(Collision col) {
		if (col.gameObject.name == "Ground" && !collision) {
			AudioSource audioSource = GetComponent<AudioSource>();
			audioSource.Stop();
			audioSource.clip = impact;
			audioSource.Play();
			collision = true;
			GameObject dust = Instantiate(dustGO);
			ParticleSystem dustCloud = dust.GetComponent<ParticleSystem>();
			dustCloud.Play();
			dustCloud.transform.position = transform.position;
			//Destroy(dust, 2f);
		}
	}
}