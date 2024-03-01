using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class SistemaDeDialogo : MonoBehaviour
{
    private DialogoSO dialogoActual;

    [SerializeField] private GameObject marcoDialogo;
    [SerializeField] private TMP_Text textoDialogo;
    [SerializeField] private GameManagerSO gM;

    private int indiceFrase = 0;
    private bool escribiendo;


    private void OnEnable()
    {
        gM.DialogoIniciado += OnDialogoIniciado;
    }

    private void OnDialogoIniciado(DialogoSO dialogoRecibido)
    {
        if (dialogoActual == null)
        {
            // INICIO NUEVO DIÁLOGO
            dialogoActual = dialogoRecibido;
            IniciarDialogo();
        }
        else if (escribiendo)
        {
            CompletarFrase();
        }
        else
        {
            SiguienteFrase();
        }
    }
    private void IniciarDialogo()
    {
        marcoDialogo.SetActive(true);
        StartCoroutine(EscribirFrase());
    }
    private void CompletarFrase()
    {
        StopAllCoroutines(); // MATA TODA CORRUTINA QUE ESTÉ EN EJECUCIÓN

        textoDialogo.text = dialogoActual.Frases[indiceFrase];

        escribiendo = false;
    }
    private void SiguienteFrase()
    {
        indiceFrase++;
        if (indiceFrase >= dialogoActual.Frases.Length)
        {
            TerminarDialogo();
        }
        else
        {
            StartCoroutine(EscribirFrase());
        }
    }
    private void TerminarDialogo()
    {
        dialogoActual = null;
        indiceFrase = 0;
        escribiendo = false;
        marcoDialogo.SetActive(false);
        gM.FinDeInteraccion();
    }

    private IEnumerator EscribirFrase()
    {
        escribiendo= true;

        //OBTIENE UNA FRASE (STRING) Y LA TROCEA EN UN ARRAY DE CARACTERES
        char[] caracs = dialogoActual.Frases[indiceFrase].ToCharArray();

        textoDialogo.text = string.Empty;

        for (int i = 0; i < caracs.Length; i++)
        {
            textoDialogo.text += caracs[i];
            yield return new WaitForSeconds(dialogoActual.VelocidadDialogo);
        }

        escribiendo = false;
    }

    private void OnDisable()
    {
        gM.DialogoIniciado -= OnDialogoIniciado;
    }
}
