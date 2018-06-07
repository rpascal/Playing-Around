using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ara;

[RequireComponent(typeof(AraTrail))]
public class WallPlayerController : MonoBehaviour {

    public int maxTrailLenght = 10000;

    public Color[] colors = new Color[4];

    AraTrail trail;

    void Awake() {
        trail = GetComponent<AraTrail>();
        //Color co = colors[Random.Range(0, colors.Length - 1)];
        //trail.initialColor = co;
    }

    void FixedUpdate() {

        // get current position and target:
        Vector3 pos = transform.position;

        print(trail);
        trail.initialColor = colors[Random.Range(0, colors.Length - 1)];
        trail.EmitPoint(pos);


        // Remove excess points once weve reached the limit:
        //int excess = Mathf.Max(0, trail.points.Count - maxTrailLenght);
        //if (excess > 0) {
        //    trail.points.RemoveRange(0, excess);
        //}

    }

}
