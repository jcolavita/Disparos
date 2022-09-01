using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruirparticulas : MonoBehaviour
{
    //este script es para no dejar rastro de las particulas que se crean al destruir una diana
    void Start()
    {
        Invoke("destruir", 0.3f);
    }

    public void destruir()
    {
        Destroy(gameObject);
    }


    
}
