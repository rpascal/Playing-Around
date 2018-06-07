using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {

    LineRenderer lineRenderer;


    // Use this for initialization
    void Start () {
        lineRenderer = gameObject.GetComponent<LineRenderer>();

       lineRenderer.SetPosition(0, transform.position);


    }

    // Update is called once per frame
    void LateUpdate () {
        print(transform.position);
        lineRenderer.SetPosition(1, transform.position);
    }
}
