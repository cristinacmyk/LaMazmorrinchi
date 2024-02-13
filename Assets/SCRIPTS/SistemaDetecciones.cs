using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaDetecciones : MonoBehaviour
{
    // POO: ABSTRACCIÓN (CÓMO¿?) ENCAPSULAMIENTO (PORTEGER EL ACCESO A LAS VARIABLES CON GET Y SET) 
    // POLIMORFISMO (VER LAS COSAS COMO DE DIFERENTE TIPO O CLASE) HERENCIA (LAS CLASES HEREDAN DE OTRAS CLASES)

    [Header("Detecciones")]
    [SerializeField] private Transform puntoInteraccion;
    [SerializeField] private float radioDeteccion ;
    [SerializeField] private LayerMask queEsInteractuable;


    void Start()
    {
        
    }

    void Update()
    {
        
    }
  
    private void FixedUpdate() // CICLO DE FÍSICAS: 0.02 SEGUNDOS
    {
        DetectarInteractuables();
    }

    private void DetectarInteractuables()
    {
        Collider[] colls = Physics.OverlapSphere(puntoInteraccion.position, radioDeteccion, queEsInteractuable);

        if(colls.Length > 0) // SI SE HA DETECTADO AL MENOS 1...
        {
            colls[0].GetComponent<Interactuable>().Interactuar();
        }
    }
}
