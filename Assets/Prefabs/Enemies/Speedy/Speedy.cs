using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedy : BaseEnemy {

    public Speedy() : base() {

    }

    protected override void Awake() {
        Speed = 300f;
        Acceleration = 40f;
        base.Awake();
    }

}
