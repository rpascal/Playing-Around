using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DirectionState {
    FORWARD,
    BACK,
    LEFT,
    RIGHT
}

public class CubeMovement : MonoBehaviour {

    [SerializeField] LineRenderer line;
    [SerializeField] ParticleSystem ParticleSystem;


    ParticleSystem.EmissionModule emissionModule;

    Vector3 dir;
    DirectionState directionState = DirectionState.FORWARD;
    bool isDirectionChange = false;
    //int verticesCount = 0;

    // Use this for initialization
    void Start() {
        emissionModule = ParticleSystem.emission;
        dir = Vector3.forward;

        emissionModule.enabled = true;

        //AddLineVertice();
    }




    void Update() {

        //ParticleSystem.transform.position = transform.position;

        if (Input.GetKeyDown(KeyCode.W) && directionState != DirectionState.FORWARD) {
            dir = Vector3.forward;
            directionState = DirectionState.FORWARD;
            isDirectionChange = true;
        } else if (Input.GetKeyDown(KeyCode.A) && directionState != DirectionState.LEFT) {
            dir = Vector3.left;
            directionState = DirectionState.LEFT;
            isDirectionChange = true;
        } else if (Input.GetKeyDown(KeyCode.S) && directionState != DirectionState.BACK) {
            dir = Vector3.back;
            directionState = DirectionState.BACK;
            isDirectionChange = true;
        } else if (Input.GetKeyDown(KeyCode.D) && directionState != DirectionState.RIGHT) {
            dir = Vector3.right;
            directionState = DirectionState.RIGHT;
            isDirectionChange = true;
        }


        //if (Input.GetKey(KeyCode.Space)) {
        //    emissionModule.enabled = true;
        //} else {
        //    emissionModule.enabled = false;
        //}

        if (isDirectionChange) {
            //AddLineVertice();

            isDirectionChange = false;
        }

        transform.Translate(dir * 10f * Time.deltaTime);
    }



    //private void AddLineVertice() {
    //    line.positionCount = (verticesCount + 1);
    //    line.SetPosition(verticesCount, transform.position);
    //    verticesCount++;
    //}

}
