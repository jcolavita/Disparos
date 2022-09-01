using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//este nuevo script de camara se utiliza directamente en la camara
public class Camara : MonoBehaviour
{

    public RawImage reticula; //referencia desde el inspector para llamar la imagen de la reticula al hacer zoom
    public float sensibilidad = 80f;
    public Transform personaje;
    float rotacion;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //bloquea el cursor para que no se salga de la pantalla y lo oculta 
    }

    private void FixedUpdate()
    {
        movercamra();
        if (Input.GetKeyDown("left alt")) zoom(); //detecta si se ha pulsado la tecla alt y llama el metodo para hacer el zoom
    }

    void zoom()
    {
        if (Camera.main.fieldOfView == 72) // si el zoom esta desactivado hace el zoom, en caso contrario lo quita
        {
            Camera.main.fieldOfView = 40;
            reticula.enabled = true;
        }
        else
        {
            Camera.main.fieldOfView = 72;
            reticula.enabled = false;
        }
    }

    private void movercamra()//nuevo metodo de camara
    {
        float hor = Input.GetAxis("Mouse X") * sensibilidad * Time.fixedDeltaTime;
        float ver = Input.GetAxis("Mouse Y") * sensibilidad * Time.fixedDeltaTime;

        rotacion -= ver; //a la rotacion se le resta el valor de vertical para obtener el angulo que va a tener la camara
        rotacion = Mathf.Clamp(rotacion, -90, 90);//limita la rotacion en 90 tanto inferior como superior
        transform.localRotation = Quaternion.Euler(rotacion, 0, 0); //el valor de rotacion obtenido de la resta se aplica unicamente en el eje x para poder mirar arriba y abajo
        personaje.Rotate(Vector3.up * hor);// en base a hor rota, en este caso no se rota la camara si no directamente el personaje


    }
}
