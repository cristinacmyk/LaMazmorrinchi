using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // INCLUSIÓN DEL NUEVO SISTEMA DE INPUTS

public class Player : MonoBehaviour
{

    private CharacterController controller;

    [SerializeField] private float velocidadAndar;

    private Vector3 vectorMovimiento;

    private Controles misControles;


    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    // SE EJECUTA AUTOMÁTICAMENTE ANTES DEL START CADA VEZ QUE SE ACTIVA EL OBJETO
    private void OnEnable()
    {
        misControles = new Controles(); // PARA DAR VALOR A LA VARIABLE Y NO SE QUEDE EN NULL

        misControles.Gameplay.Enable(); // PARA HABILITAR O DESHABILITAR CONTROLES. EJEM: EN UNA CINEMÁTICA PONES DISABLE

        misControles.Gameplay.Interactuar.started += Interactuar; // SI SE PULSA LA E SE EJECUTA EL EVENTO (EN ESTE CASO EL DE INTERACTUAR)

        misControles.Gameplay.Moverse.performed += Moverse;
        misControles.Gameplay.Moverse.canceled += MoverseCanceled;


    }

    // MOVERSE
    private void Moverse(InputAction.CallbackContext ctx) // CTX DE CONTEXTO
    {
        //Debug.Log("Me muevo hacia... " + ctx.ReadValue<Vector2>());

        Vector2 input = ctx.ReadValue<Vector2>();

        vectorMovimiento = new Vector3(input.x, 0, input.y);

    }
    private void MoverseCanceled(InputAction.CallbackContext ctx)
    {
        //Debug.Log("Me muevo hacia... " + ctx.ReadValue<Vector2>());

        Vector2 input = ctx.ReadValue<Vector2>();

        vectorMovimiento = new Vector3(input.x, 0, input.y);

    }  

    // INTERACTUAR
    private void Interactuar(InputAction.CallbackContext obj)
    {
        Debug.Log("Interactuo!!");
    }


    void Start()
    {
        
    }

    void Update()
    {
        controller.Move(vectorMovimiento * velocidadAndar * Time.deltaTime);
    }
}
