using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    
    public float ScrollSpeed = 6.0f;  // Velocidad inicial de desplazamiento
    public float accelerationRate = 0.5f;    // Tasa de aceleración
    private float timeElapsed = 0f;        // Tiempo transcurrido desde el inicio
   

    // Update is called once per frame
    void Update()
    {
        // Aumenta el tiempo transcurrido
        timeElapsed += Time.deltaTime;

        // Calcula la velocidad de desplazamiento en función del tiempo transcurrido
        float currentScrollSpeed = ScrollSpeed + accelerationRate * timeElapsed;

        // Mueve el objeto con la velocidad calculada
        transform.Translate(Vector2.left * currentScrollSpeed * Time.deltaTime);
        

    }
}
