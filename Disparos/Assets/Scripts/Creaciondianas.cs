using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creaciondianas : MonoBehaviour
{

    public GameObject dianas;
   
    void Start()
    {
        creardiana();//crea la primera diana para iniciar el bucle infinito de creacion de dianas
    }

    public void creardiana()
    {
        float x = Random.Range(-10, 10), z = Random.Range(0, 30), y = Random.Range(2, 7); //variable de las posiciones aleatorias en x y z
        Instantiate(dianas, new Vector3 (x,y,z),Quaternion.identity );// creacion del objeto instanciado en las coordenadas aleatorias
        Invoke("creardiana", 3);//despues de creada la diana este se llama a si mismo con un tiempo de espera de 3s para seguir creandose infinitamente
    }
}
