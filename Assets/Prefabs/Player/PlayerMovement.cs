using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] ParticleSystem ParticleSystem;
    [SerializeField] float speed = 25f;


    Rigidbody playerRigidbody;
    ParticleSystem.EmissionModule emissionModule;
    Vector3 currentDirection;

    void Start() {
        playerRigidbody = GetComponent<Rigidbody>();
        emissionModule = ParticleSystem.emission;
        currentDirection = Vector3.forward;
    }


    void Update() {
        UpdateDirection();
        DisplayTrail();
        Move();
    }

    private void Move() {
        var movement = currentDirection * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

    private void DisplayTrail() {
        if (Input.GetKey(KeyCode.Space)) {
            emissionModule.enabled = true;
        } else {
            emissionModule.enabled = false;
        }
    }

    private void UpdateDirection() {
        if (isChangingDirection(KeyCode.W, Vector3.forward)) {
            currentDirection = Vector3.forward;
        } else if (isChangingDirection(KeyCode.A, Vector3.left)) {
            currentDirection = Vector3.left;
        } else if (isChangingDirection(KeyCode.S, Vector3.back)) {
            currentDirection = Vector3.back;
        } else if (isChangingDirection(KeyCode.D, Vector3.right)) {
            currentDirection = Vector3.right;
        }
    }

    private bool isChangingDirection(KeyCode key, Vector3 direction) {
        return (Input.GetKeyDown(key) && currentDirection != direction);
    }

}
