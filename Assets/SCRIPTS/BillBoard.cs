using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    // EL BILLBOARD ES PARA QUE ALGO SIEMPRE MIRA A LA CÁMARA

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        transform.rotation = Camera.main.transform.rotation; 
    }
}
