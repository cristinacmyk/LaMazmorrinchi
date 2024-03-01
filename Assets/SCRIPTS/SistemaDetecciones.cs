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
    [SerializeField] private GameManagerSO gM;

    private Interactuable interactuableActual;

    private Controles misControles;

    private bool interactuando;

    private SistemaMovimiento miMovimiento;

    private void Awake()
    {
        miMovimiento = GetComponent<SistemaMovimiento>();
    }
    private void OnEnable()
    {
        misControles = new Controles();
        misControles.Gameplay.Enable();
        misControles.Gameplay.Interactuar.started += Interactuar;

        gM.InteraccionFinalizada += FinalizarInteraccion;
    }

    private void FinalizarInteraccion()
    {
        interactuableActual = null;
        miMovimiento.enabled = true;
        interactuando = false;
    }

    //FUNCIÓN PARA LANZAR INTERACCIONES EN LO QUE TENGA DE FRENTE
    private void Interactuar(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if(interactuableActual != null)
        {
            miMovimiento.enabled = false;
            interactuableActual.Interactuar(this);
            interactuando= true;
        }
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    } 
    private void FixedUpdate() // CICLO DE FÍSICAS: 0.02 SEGUNDOS
    {
        if(!interactuando)
        {
            DetectarInteractuables();
        }
    }

    private void DetectarInteractuables()
    {
        Collider[] colls = Physics.OverlapSphere(puntoInteraccion.position, radioDeteccion, queEsInteractuable);

        if(colls.Length > 0) // SI SE HA DETECTADO AL MENOS 1...
        {
            interactuableActual = colls[0].GetComponent<Interactuable>();
            interactuableActual.CambiarEstadoIcono(true);
        }
        else if (interactuableActual != null)
        {
            interactuableActual.CambiarEstadoIcono(false);
            interactuableActual = null;
        }
          
    }
}
