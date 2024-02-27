using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaDeCombate : MonoBehaviour
{ 
    private Controles controles;
    private Animator anim;

    private bool coolingDown, atacando, puedeCombo = true;

    [SerializeField, Tooltip("Tiempo de enfriamiento tras combo")]
    private float tiempoCoolDown;

    [SerializeField, Tooltip("Cuántos ataques por combo")]
    private int ataquesDeCombo;

    private int estadoDeAtaque;
    private float timerAtacar;

    private void Awake()
    {
        anim= GetComponentInChildren<Animator>();
    }
    private void OnEnable()
    {
        controles= new Controles();
        controles.Enable();
        controles.Gameplay.Atacar.started += Ataque;
    }

    private void Ataque(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        // SI PUEDO HACER COMBO Y NO ESTOY EN COOLING DOWN
        if(puedeCombo && !coolingDown)
        {
            // NUEVO ATAQUE
            estadoDeAtaque++;

            // SI MI ESTADO SUPERA A LOS ATAQUES DISPONIBLES...
            if (estadoDeAtaque > ataquesDeCombo)
            {
                estadoDeAtaque = 1;
            }
            anim.SetInteger("estadoAtaque", estadoDeAtaque);
            puedeCombo = false;
        }
        
    }

    void Update()
    {
        ActualizarTimer();
    }

    private void ActualizarTimer()
    {
        if (coolingDown)
        {
            // CUENTO...
            timerAtacar += Time.deltaTime;

            // Y SI HEMOS PASADO EL TIEMPO DE COOL DOWN
            if (timerAtacar > tiempoCoolDown)
            {
                // YA NO ESTOY EN COOL DOWN
                coolingDown = false;
                timerAtacar = 0;
                ResetearCombo();
            }
        }
    }
    private void ResetearCombo()
    {
        estadoDeAtaque = 0;
        anim.SetInteger("estadoAtaque", estadoDeAtaque);
        puedeCombo = true;
    }

    #region EVENTOS DE ANIMACIÓN
    private void VentanaDeCombo()
    {
        puedeCombo= true;
    }
    private void FinAnimacionAtaque()
    {
        // SI HAS LLEGADO AQUÍ Y TERMINASTE EL ATAQUE...
        if(estadoDeAtaque == 3)
        {
            // ACTIVO COOL DOWN
            coolingDown= true;
        }
        ResetearCombo();
    }
    #endregion
}
