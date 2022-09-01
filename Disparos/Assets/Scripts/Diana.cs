using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diana : MonoBehaviour
{
    public GameObject escombros;
    public AudioSource impacto;

    //este script va incluido en el prefab y en el start llama el metodo de desaparecer las dianas despues de 8s para que el jugador deba dispararles rapido
    //antes de que desaparescan
    void Start()
    {
        Invoke("desaparecer", 7); 
    }

    void desaparecer()
    {
     Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "bala") //solo si la diana entra en colision con un objeto con el tag de bala sera destruido
        {
            Destroy(gameObject);//destgruye el objeto
            Instantiate(escombros, transform.position, Quaternion.identity);//crea un efecto de particulas al ser destruida la diana

        }

    }
}
