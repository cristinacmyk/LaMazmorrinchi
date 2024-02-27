using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // INCLUSI�N DEL NUEVO SISTEMA DE INPUTS

public class SistemaMovimiento : MonoBehaviour
{

    private CharacterController controller;

    [SerializeField] private float velocidadAndar;
    [SerializeField] private float suavidadRotacion;
    private float velocidadDeRotacion;


    [SerializeField] private Transform pies;
    [SerializeField] private LayerMask queEsSuelo;
    [SerializeField] private float factorGravedad;
    [SerializeField] private float radioDeteccion;

    private bool enSuelo;
    [SerializeField] private float alturaSalto;

    private Vector3 vectorMovimiento, vectorVertical; // SIRVE TANTO PARA SALTOS COMO PARA LA GRAVEDAD
    private Vector3 input; // �NDICE DIRECCI�N DE MOVIMIENTO

    private Controles misControles;

    private Animator anim;
        
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    // SE EJECUTA AUTOM�TICAMENTE ANTES DEL START CADA VEZ QUE SE ACTIVA EL OBJETO
    private void OnEnable()
    {
        misControles = new Controles(); // PARA DAR VALOR A LA VARIABLE Y NO SE QUEDE EN NULL

        misControles.Gameplay.Enable(); // PARA HABILITAR O DESHABILITAR CONTROLES. EJEM: EN UNA CINEM�TICA PONES DISABLE      

        misControles.Gameplay.Moverse.performed += Moverse;
        misControles.Gameplay.Moverse.canceled += MoverseCanceled; // CANCEL ES CUANDO QUITAS EL DEDO DEL BOT�N

        misControles.Gameplay.Saltar.started += Saltar;
       
    }

    // SALTAR
    private void Saltar(InputAction.CallbackContext obj)
    {
        if (enSuelo)
        {
            vectorVertical.y = Mathf.Sqrt(-2 * factorGravedad * alturaSalto);
            anim.SetTrigger("jump");
            anim.SetBool("grounded", false);
        }       
    }

    // MOVERSE
    private void Moverse(InputAction.CallbackContext ctx) // CTX DE CONTEXTO
    {
        input = ctx.ReadValue<Vector2>();

        anim.SetFloat("velocidad", input.magnitude);

        input = new Vector3(input.x, 0, input.y);
    }
    private void MoverseCanceled(InputAction.CallbackContext ctx)
    {
        input = ctx.ReadValue<Vector2>();

        anim.SetFloat("velocidad", input.magnitude);

        input = new Vector3(input.x, 0, input.y);
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (input.magnitude > 0) // SI HAY MOVIMIENTO
        {
            // CALCULAMOS EL �NGULO AL QUE APUNTA MI INPUT PERO RELATIVO A LA ANGULACI�N QUE YA TRAE LA C�MARA DE POR S�
            float anguloObjetivo = Mathf.Atan2(input.x, input.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;

            // EL �NGULO CALCULADO ARRIBA, LO SUAVIZAMOS PARA NO GIRAR DE GOLPE
            float anguloSuavizado = Mathf.SmoothDampAngle(transform.eulerAngles.y, anguloObjetivo, ref velocidadDeRotacion, suavidadRotacion);

            // ASIGNAMOS DICHO �NGULO A LA ROTACI�N DEL PERSONAJE
            transform.eulerAngles = new Vector3(0, anguloSuavizado, 0);

            // MI Z GLOBAL YA NO ES LA Z GLOBAL DEL MAPA, SINO QUE EST� DESFASADA TANTO COMO SEA ANGULOOBJETIVO
            vectorMovimiento = Quaternion.Euler(0, anguloObjetivo, 0) * new Vector3(0, 0, 1);

            // NOS MOVEMOS EN BASE A DICHO VECTOR
            controller.Move(vectorMovimiento * input.magnitude * velocidadAndar * Time.deltaTime); // input.magnitude mueve el player en funci�n de cuanto inclines el joystick (multiplicas la magnitud del vector)
        }

        AplicarGravedad();
        
    }
    void AplicarGravedad()
    {
        vectorVertical.y += factorGravedad * Time.deltaTime;
        controller.Move(vectorVertical * Time.deltaTime);

        enSuelo = Physics.CheckSphere(pies.position, radioDeteccion, queEsSuelo);

        anim.SetBool("grounded", enSuelo);

        if(enSuelo && controller.velocity.y < 0) // ATERRIZAJE
        {
            vectorVertical.y = 0;
            anim.SetBool("falling", false);
        }
        else if(controller.velocity.y < 0) // CA�DA
        {
            anim.SetBool("falling", true);
        }
    }

}
