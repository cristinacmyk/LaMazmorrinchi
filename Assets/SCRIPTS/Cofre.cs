using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : Interactuable
{
    public override void Interactuar()
    {
        Debug.Log(gameObject.name);
    }
}
