using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaPatrulla : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        foreach (Transform punto in this.transform) // POR CADA PUNTO EN THIS.TRANSFORM SE DIBUJA UNA ESFERA
        {
            Gizmos.DrawSphere(punto.position, 0.3f);
        }
    }
}
