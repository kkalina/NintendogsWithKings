using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadLevel : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
            SceneManager.LoadScene("Karls_Kastle_Test");
    }

}
