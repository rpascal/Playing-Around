using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {


    void Start() {

    }

    void Update() {
        transform.Translate(Vector3.left * 1f * Time.deltaTime);
    }

    private void OnParticleCollision(GameObject other) {
        Destroy(gameObject);
    }

}
