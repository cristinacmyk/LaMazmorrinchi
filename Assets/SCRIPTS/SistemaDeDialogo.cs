using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class SistemaDeDialogo : MonoBehaviour
{
    [SerializeField] private DialogoSO dialogoActual;
    [SerializeField] private TMP_Text textoDialogo;
    void Start()
    {
        StartCoroutine(EscribirFrase());
    }

    void Update()
    {
        
    }
    private IEnumerator EscribirFrase()
    {
        //OBTIENE UNA FRASE (STRING) Y LA TROCEA EN UN ARRAY DE CARACTERES
        char[] caracs = dialogoActual.Frases[0].ToCharArray();

        for (int i = 0; i < caracs.Length; i++)
        {
            textoDialogo.text += caracs[i];
            yield return new WaitForSeconds(dialogoActual.VelocidadDialogo);
        }
    }
}
