using UnityEngine;
using System.Collections;

public class PointToKing : MonoBehaviour {

    public Transform king;


    // Update is called once per frame
    void Update() {
        transform.LookAt(king);
    }    
}
