using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//mismo script de movimiento del juego anterior, se cambio la camara a un script independiente
public class Personaje : MonoBehaviour
{
    #region variables 
    public float velocidad;
    public Rigidbody rig; //variable utilizada para poder asignar el rigidbody desde el inspector 
    #endregion

    private void FixedUpdate(){actualizarmovimiento();}
  
    private void actualizarmovimiento()
    {
        float hor = Input.GetAxisRaw("Horizontal"); // variables donde se almacena si es pulsado o no las teclas
        float ver = Input.GetAxisRaw("Vertical");

        Vector3 velocity = Vector3.zero; //almacena la velocidad inicial 

        if (hor != 0 || ver != 0) //identifica si alguno de los dos ejes es modificado y procede a añadir fuerza en la direccion
        {
            Vector3 direction = (transform.forward * ver + transform.right * hor).normalized; //el normalized es utilizado para normalizar la velocidad y que no se sumen al ir en diagonal

            velocity = direction * velocidad*Time.fixedDeltaTime  ; //se establece la nueva velocidad que tendra aplicando las fuerzad segun la direccion
        }

        velocity.y = rig.velocity.y;
        rig.velocity = velocity; //se le aplica las fuerza al perconaje
    }
}
    
