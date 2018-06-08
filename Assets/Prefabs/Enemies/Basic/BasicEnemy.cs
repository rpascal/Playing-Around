using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : BaseEnemy {



    public BasicEnemy(): base() {
    }

    protected override void Awake() {
        Speed = 50f;
        base.Awake();
    }

}
