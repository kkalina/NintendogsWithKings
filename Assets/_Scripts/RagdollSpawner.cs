using UnityEngine;
using System.Collections;

public class RagdollSpawner : MonoBehaviour {

    public GameObject NPC;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    private float counter;


    void Start ()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }

    void Update() {
    	counter += Time.deltaTime;
    	if (counter > 60 && spawnTime > 1) {
    		counter = 0;
    		spawnTime--;
    		CancelInvoke("Spawn");
    		InvokeRepeating("Spawn", spawnTime, spawnTime);
    	}
    }

    void Spawn ()
    {
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate (NPC, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
