using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_ : Interactuable
{
    // TIEMPO EN EL QUE LOLA TARDA EN ROTAR
    [SerializeField] private float tiempoRotar;

    [SerializeField] private DialogoSO miDialogo;
    [SerializeField] private GameManagerSO gM;

    private SistemaPatrulla sistemaPatrulla;

    private Animator anim;

    private SistemaDetecciones interactuadorActual;

    private void Awake()
    {
        sistemaPatrulla = GetComponent<SistemaPatrulla>();
        anim = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        gM.InteraccionFinalizada += VolverAPatrullar;
    }

    private void VolverAPatrullar()
    {
        interactuadorActual = null;
        sistemaPatrulla.enabled = true;
        anim.SetBool("talking", false);
    }

    public override void Interactuar(SistemaDetecciones interactuador)
    {
       interactuadorActual = interactuador;
       sistemaPatrulla.enabled = false;
       CambiarEstadoIcono(false);
       StartCoroutine(EnfocarInteractuador());
    }
    private IEnumerator EnfocarInteractuador()
    {
        float timer = 0f;

        Quaternion rotacionInicial = transform.rotation;

        Vector3 direccionAplayer = (interactuadorActual.transform.position - transform.position).normalized;

        direccionAplayer.y = 0; // PREVENIR QUE LA DIRECCIÓN NO SE TUMBE

        Quaternion rotacionFinal = Quaternion.LookRotation(direccionAplayer);    

        while (timer < tiempoRotar)
        {
            transform.rotation = Quaternion.Slerp(rotacionInicial, rotacionFinal, timer / tiempoRotar);
            timer += Time.deltaTime;
            yield return null;
        }

        anim.SetBool("talking", true);

        // NPC NECESITA COMUNICARSE CON EL SISTEMA DE DIÁLOGO
        gM.IniciarDialogo(miDialogo);

    }
}
