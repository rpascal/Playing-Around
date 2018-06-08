using Ara;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerMovement : MonoBehaviour {

    [SerializeField] AraTrail trail;
    [SerializeField] float speed = 25f;
    public Vector3 startingDirection = Vector3.right;
    public bool trailAlwaysOn = false;

    Rigidbody playerRigidbody;

    Vector3 currentDirection;


    void Awake() {
        playerRigidbody = GetComponent<Rigidbody>();
        currentDirection = startingDirection;
        playerRigidbody.freezeRotation = true;
        trail.emit = false;
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
        if (trailAlwaysOn) { trail.emit = true; return; }
        if (Input.GetKey(KeyCode.Space)) {
            trail.emit = true;
        } else {
            trail.emit = false;
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
