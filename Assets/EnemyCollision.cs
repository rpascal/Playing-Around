using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {



    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.left * 1f * Time.deltaTime);
    }

    private void OnParticleCollision(GameObject other) {
        print(other);
        Destroy(gameObject);
    }


    private void OnParticleTrigger() {
        print("OnParticleTrigger");

    }

}
