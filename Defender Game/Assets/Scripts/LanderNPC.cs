using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanderNPC : NPC
{
    public void Start()
    {
        score = 100;
        movementSpeed = 2f;
        usesRandomMovement = false;
    }

    public override void Update()
    {
        base.Update();
    }
}
