using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_ : Interactuable
{
    // TIEMPO EN EL QUE LOLA TARDA EN ROTAR
    [SerializeField] private float tiempoRotar;

    private Lola sistemaPatrulla;

    private Animator anim;

    private SistemaDetecciones interactuadorActual;

    private void Awake()
    {
        sistemaPatrulla = GetComponent<Lola>();
        anim = GetComponent<Animator>();
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
    }
}
