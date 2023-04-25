using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class PorteriaScript : MonoBehaviour
{
    public int numPorteria;
    private void OnTriggerEnter(Collider other)
    {

        if (numPorteria == 1)
        Debug.Log("equipo 2 anoto gol");
        GameManager.instancia.Gol1();

        if (numPorteria == 2)
        Debug.Log("equipo 1 anoto gol");
        GameManager.instancia.Gol2();       
    }
        
}
