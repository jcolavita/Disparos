using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    public GameObject bala;//referencia para la instancia de la bala
    public Transform boquilla;//punto de referencia de donde salen las balas
    public float fuerzadisparo;
    public float cadencia = 0;//variable que se utilziara para determinar una cadencia de disparo
    public AudioSource sonido;


    void Update()
    {
        if (Input.GetKey("mouse 0"))
        {
            if(Time.time>cadencia)//comprueba si el tiempo transcurrido es mayor a la variable de cadencia, en caso de serlo dispara
            {
                GameObject nuevabala;//creacion de un gameobject para poder utilizar la funcion de destruir en el y las balas no se acumulen en pantalla
                nuevabala = Instantiate(bala, boquilla.position, boquilla.rotation);//se instancia la bala en el punto de la boquilla y con el gameobject
                nuevabala.GetComponent<Rigidbody>().AddForce(boquilla.forward * fuerzadisparo * Time.fixedDeltaTime);//se añade la fuerza para el disparo
                Destroy(nuevabala, 5); //se destrulle la bala luego de 5s 

                cadencia = Time.time + 0.25f;//despues de cada disparo el contador sera el tiempo actual mas 0.25 por lo cual no se puede disparar inmediatamente

                sonido.Play();
            }
            
        }
    }
}

