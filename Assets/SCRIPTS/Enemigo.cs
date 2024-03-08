using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    private Transform target;
    //private float dano = 2;

    [Header("OverLap")]
    [SerializeField] private float radioVision;
    [SerializeField] private LayerMask queEsTarget;

    [Header("Angulo vista")]
    [SerializeField] private float anguloVision;
    [SerializeField] private LayerMask queEsObstaculo;

    [Header("Atacar")]
    [SerializeField] private float tiempoEntreAtaques;
    //[SerializeField] private Transform puntoDeAtaqque;
    //[SerializeField] private LayerMask queEsAzotable;
    //[SerializeField] private float radioAtaque;

    private float timer;
    //private int vida = 5;

    #region Mis Componentes
    private NavMeshAgent agent;
    private SistemaPatrulla sistemaPatrulla;
    private Animator anim;
    #endregion

    private enum Estado { Patrullar, Perseguir, Atacar }
    Estado estadoActual;

    public float RadioVision { get => radioVision;}
    public float AnguloVision { get => anguloVision;}

    void Start()
    {
        estadoActual = Estado.Patrullar;
        agent= GetComponent<NavMeshAgent>();
        sistemaPatrulla = GetComponent<SistemaPatrulla>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {     
        if (estadoActual == Estado.Perseguir)
        {
            Perseguir();
        }
        else if (estadoActual == Estado.Atacar)
        {
            Atacar();
        }
    }
    private void FixedUpdate()
    {
        if (estadoActual == Estado.Patrullar)
        {
            DetectarTargets();
        }
    }
    private void DetectarTargets()
    {
        Collider[] collsDetectados = Physics.OverlapSphere(transform.position, radioVision, queEsTarget);

        if (collsDetectados.Length > 0) // HAS PASADO EL PRIMER CHECK
        {
            target = collsDetectados[0].transform;

            Vector3 direccionATarget = (target.position - transform.position).normalized; // DESTINO(PLAYER) - ORIGEN(ENEMIGO) Y NORMALIZAMOS

            if (Vector3.Angle(transform.forward, direccionATarget) <= anguloVision / 2) // SEGUNDO CHECK
            {
                if (! Physics.Raycast(transform.position, direccionATarget, radioVision, queEsObstaculo)) // TERCER CHECK
                {
                    agent.isStopped = true;
                    anim.ResetTrigger("IsAlert");
                    anim.SetTrigger("IsAlert");
                    Invoke(nameof(Alerta), 0.5f); // LLAMAR A LA FUNCIÓN CON RETARDO
                }
            }
        }
    }

    private void Alerta()
    {
        // TE HE VISTO!!!!!!!!!!!!!!!!!!!!
        estadoActual = Estado.Perseguir;
    }
    private void Perseguir()
    {
        sistemaPatrulla.enabled = false;
        agent.enabled = true;
        agent.speed = 3f;
        agent.stoppingDistance = 1.5f; // DISTANCIA A LA QUE EL ENEMIGO SE QUEDA DEL PLAYER
        agent.SetDestination(target.position);

        if (agent.remainingDistance <= agent.stoppingDistance) // PARA ATACAR
        {
            estadoActual = Estado.Atacar;
        }
        else if (agent.remainingDistance > radioVision) // PARA PERDER DE VISTA
        {
            sistemaPatrulla.enabled = true;
            agent.stoppingDistance = 0;
            agent.speed = 1f;
            estadoActual = Estado.Patrullar;
        }
    }
    private void Atacar()
    {
        timer += Time.deltaTime;
        if (timer >= tiempoEntreAtaques)
        {
            agent.isStopped = true;
            anim.SetTrigger("Attack");
            //Collider[] collsTocados = Physics.OverlapSphere(transform.position, radioVision, queEsTarget);


            //if (collsTocados.Length > 0)
            //{
            //    collsTocados[0].GetComponent<SistemaDeCombate>().RecibirDano(dano);
            //}
            timer = 0f;

            if (Vector3.Distance(transform.position, target.position) > 1.5f)
            {
                timer = tiempoEntreAtaques;
                agent.isStopped = false;
                estadoActual = Estado.Perseguir;
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    //private void OndrawGizmos()
    //{
    //    Gizmos.DrawSphere(puntoDeAtaque.position, radioAtaque);
    //}
}
