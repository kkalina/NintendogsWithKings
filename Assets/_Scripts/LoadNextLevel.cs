using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour {


    // Update is called once per frame
    void OnTriggerEnter(Collider other) {
        Debug.Log("load damn it");
        if (other.tag == "Player") {
            
            SceneManager.LoadScene("Karls_Kastle_Test");
            
        }
    }
}
