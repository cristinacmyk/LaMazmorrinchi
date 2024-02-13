using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactuable : MonoBehaviour
{
    // UNA INTERFAZ ES COMO APORTAR UNA HABILIDAD
    // CONJUNTO DE FUNCIONES A IMPLEMENTAR. (AQUEL QUE SE COMPORTE COMO UN INTERACTUABLE Y TENGA ESTA ETIQUETA TIENE QUE CUMPLIR ESTAS FUNCIONES) TIENEN QUE SER PUBLIC
    // SI NECESITO VARIABLES NECESITO HACER ABSTRACT CLASS, QUE TENDRÁ FUNCIONES CON Y SIN CUERPO
    [SerializeField] private GameObject canvasLocal;

    public abstract void Interactuar();
}
