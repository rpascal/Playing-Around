using Ara;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrailCollider : MonoBehaviour {

    private RaycastHit hit;
    private AraTrail trail;
    private LayerMask nonPlayerLayers;

    public float maxDistanceApart = 1f;

    void Start() {
        trail = GetComponent<AraTrail>();
        nonPlayerLayers = ~LayerMask.GetMask("Player");
    }

    void Update() {
        CheckHits();
    }

    bool CheckHits() {
        if (trail.points.Count < 2) {
            return false;
        }
        for (int i = 0; i < trail.points.Count - 1; ++i) {
            var point = trail.points[i].position;
            var nextPoint = trail.points[i + 1].position;
            if (Physics.Linecast(point, nextPoint, out hit, nonPlayerLayers, QueryTriggerInteraction.Collide) && Vector3.Distance(point, nextPoint) < maxDistanceApart) {
                Destroy(hit.collider.gameObject);
                //return true;
            }
        }
        return false;
    }
}
