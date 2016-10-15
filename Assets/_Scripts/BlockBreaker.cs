using UnityEngine;
using System.Collections;

/// <summary>
/// This class will cause the block to break into pieces, if it is hit by a strong enough force.
/// </summary>
public class BlockBreaker : Weight {

	/// <summary>
	/// An array of GameObject prefabs to spawn when this object is broken
	/// </summary>
	public GameObject[] debrisPrefabs;
	
	/// <summary>
	/// An array of transform points to spawn the debris object at
	/// </summary>
	public Transform[] debrisSpawnPoints;
	
	/// <summary>
	/// The minimum force needed to break this object
	/// </summary>
	public float breakForceMinimum = 1.0f;
	
	/// <summary>
	/// Enable or disable the break effect
	/// </summary>
	public bool enableBreak = true;
	
	/// <summary>
	/// If true the debris will have the same parent as the original
	/// </summary>
	public bool copyParent = true;
	
	/// <summary>
	/// If true the debris will have the same velocity as the original object
	/// </summary>
	public bool copyVelocity = true;
	
	/// <summary>
	/// A random velocity range to impart to each debris object
	/// </summary>
	public Vector3 randomVelocity = Vector3.zero;
	
	/// <summary>
	/// When true, will inhibit a break from occuring if the other object is bouncy enough
	/// </summary>
	public bool inhibitBreakOnBounce = false;
	
	/// <summary>
	/// The minimum bounce needed to inhibit the object from breaking.  Only used if inhibitBreakOnBounce is true
	/// </summary>
	public float bouncinessMinLimit = 0.5f;
	
	/// <summary>
	/// A boolean to keep this script from running twice on the same object
	/// </summary>
	private bool _oneShot = true;
	
	void OnCollisionEnter(Collision col) {
		print("COLLISION");
		//See if the break effect is active, force is large enough, and script has not already run
		if((enableBreak == true) && (col.relativeVelocity.magnitude > breakForceMinimum) && (_oneShot == true)) {

			GetComponent<AudioSource>().Stop();

			//See if object should always break, or other object not bouncy enough to inhibit
			if((inhibitBreakOnBounce == false)||((inhibitBreakOnBounce==true)&&(col.collider.material.bounciness < bouncinessMinLimit))) {

				//Make sure the prefab array has defined elements
				if(CheckArrayForNulls(debrisPrefabs) == false) {

					//Make sure the transform array has defined elements
					if(CheckArrayForNulls(debrisSpawnPoints) == false) {
						
						//Make sure the two arrays are the same length
						if(debrisPrefabs.Length == debrisSpawnPoints.Length) {
							_oneShot = false;
							SpawnDebris();
							HitGround(col);
						}
						else
							throw new System.Exception("Length of debrisSpawnPoints array does not match the length of debrisPrefabs array");
					}
					else
						throw new System.Exception("debrisSpawnPoints contains undefined elements or is zero length");
				}
				else
					throw new System.Exception("debrisPrefabs contains undefined elements or is zero length");
			}
		}
	}
	
	/// <summary>
	/// This method will delete the current object and spawn the debris prefabs
	/// </summary>
	private void SpawnDebris() {
		//Remove any collider(s) from this object so that the new ones will not collide with it
		Collider[] colliders = this.GetComponents<Collider>();		
		foreach(Collider col in colliders)
			Destroy(col);
		
		//Spawn the new objects
		for(int i=0;i<debrisPrefabs.Length;i++) {	
			GameObject debris = (GameObject)Instantiate(debrisPrefabs[i], debrisSpawnPoints[i].position, debrisSpawnPoints[i].rotation);
			debris.transform.localScale = debrisSpawnPoints[i].localScale;
			
			//Copy parent info
			if(copyParent==true)
				debris.transform.parent = this.transform.parent;
			
			//Copy velocity
			if(copyVelocity == true) {
				if((this.GetComponent<Rigidbody>() != null) && (debris.GetComponent<Rigidbody>() != null)) {
					//copy over the velocity
					debris.GetComponent<Rigidbody>().velocity = this.GetComponent<Rigidbody>().velocity;
					
					//Randomize velocity
					if(randomVelocity.magnitude > 0.0f) {
						debris.GetComponent<Rigidbody>().velocity += new Vector3(Random.Range(-randomVelocity.x,randomVelocity.x),
						                                         Random.Range(-randomVelocity.y,randomVelocity.y),
						                                         Random.Range(-randomVelocity.z,randomVelocity.z));
					}
				}
			}
		}
	}
	
	/// <summary>
	/// Method returns true if either the array is null, any element is null or the array length is zero
	/// </summary>
	/// <param name="arr">
	/// A <see cref="Object[]"/> containing the elements to be checked
	/// </param>
	/// <returns>
	/// A <see cref="System.Boolean"/> that is true if the array is null, zero length or any element of the array is null
	/// </returns>
	private bool CheckArrayForNulls(Object[] arr) {
		bool result = false;
		
		if(arr != null) {
			if(arr.Length > 0) {
				for(int i=0;i<arr.Length;i++) {
					if(arr[i] == null) result = true;
				}
			}
			else
				result = true;
		}
		else
			result = true;
		
		return result;
	}
}
