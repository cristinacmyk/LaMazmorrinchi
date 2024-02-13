using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_ : Interactuable
{
    public override void Interactuar()
    {
        Debug.Log(gameObject.name);
    }
}
