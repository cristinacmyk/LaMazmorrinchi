using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Diálogo")]
public class DialogoSO : ScriptableObject
{
    [SerializeField, TextArea(1, 5)] private string[] frases;
    [SerializeField] private float velocidadDialogo;

    public string[] Frases { get => frases; }
    public float VelocidadDialogo { get => velocidadDialogo; }
}
