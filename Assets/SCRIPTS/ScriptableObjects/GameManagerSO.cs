using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [CreateAssetMenu(menuName = "GameManager")]

public class GameManagerSO : ScriptableObject
{
    public event Action<DialogoSO>DialogoIniciado;

    public event Action InteraccionFinalizada;

    public void IniciarDialogo(DialogoSO dialogo)
    {
        // SI HAY ALGUIEN INTERESADO EN EL EVENTO, PUES LANZAMOS EL EVENTO
        DialogoIniciado?.Invoke(dialogo);
    }
    public void FinDeInteraccion()
    {
        InteraccionFinalizada?.Invoke();
    }
}
  
