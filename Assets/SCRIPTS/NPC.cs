using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{

    [SerializeField] private Transform zonaPatrulla;
    private Animator anim;

    private NavMeshAgent agent;
    [SerializeField] private float margenDeLlegada;

    [SerializeField] private int indicePuntoActual = 0; // VA A HACER UN TRACKING DEL SIGUIENTE PUNTO AL CUAL DESPLAZARNOS

    private List<Vector3> puntosPatrulla = new List<Vector3>(); // new LIST<>...--> ES UN CONSTRUCTOR, SE DIFERENCIA DEL ARRAY EN QUE ES ILIMITADO EN ESPACIOS

    void Awake()
    {
        agent= GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        foreach (Transform punto in zonaPatrulla)
        {
            puntosPatrulla.Add(punto.position);
        }
    }
    private void Start()
    {
        StartCoroutine(PatrullaYEsperar());
    }
    void Update()
    {
       
    }

    private IEnumerator PatrullaYEsperar()
    {
        while(true)
        {
            // LA RUTINA DEL NPC
            CalcularNuevoPunto(); // 1. CALCULAS EL NUEVO PUNTO

            agent.SetDestination(puntosPatrulla[indicePuntoActual]); // 2. LE DICES A DÓNDE VA

            yield return new WaitUntil(() => !agent.pathPending); // EL NPC YA HA CALCULADO EL NUEVO PUNTO

            anim.SetBool("walking", true);

            yield return new WaitUntil(() => agent.remainingDistance <= margenDeLlegada); // 3. ME QUEDO EN ESPERA HASTA QUE LA DISTANCIA A ESTE PUNTO SEA 0

            anim.SetBool("walking", false);

            yield return new WaitForSeconds(Random.Range(1.5f, 3f)); // PARA QUE PARE CUANDO LLEGUE AL PUNTO UNOS SEGUNDOS RANDOM

        }
    }
    // SE EJECUTA ANTES DE IR A UN NUEVO PUNTO
    private void CalcularNuevoPunto()
    {
        indicePuntoActual++;

        // NO HAY MÁS PUNTOS DISPONIBLES :(
        if(indicePuntoActual >= puntosPatrulla.Count)
        {
            indicePuntoActual = 0;
        }
    }
}
