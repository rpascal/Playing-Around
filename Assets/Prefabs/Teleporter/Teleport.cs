using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public Transform target;

    // Use this for initialization
    void Start() {

    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("Player")) {
            other.transform.position = target.position;
        }
    }

}


