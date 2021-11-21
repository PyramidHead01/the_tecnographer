using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inforJuego : MonoBehaviour
{

    public Text porcentaje, tiempo, errores;

    public GameObject canvasGO;

    textoMorse textoMorse;

    void Awake()
    {
        textoMorse = GameObject.Find("ControladorBase").GetComponent<textoMorse>();
        //canvasGO = this.GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (!textoMorse.fin)
        {
            porcentaje.text = "Porcentaje: " + textoMorse.porcentaje;
            
            if (textoMorse.fallosMaximo)
                errores.text = "Errores: " + textoMorse.errores + "/" + textoMorse.fallosMax;
            else
                errores.text = "Errores: " + textoMorse.errores;

            if(textoMorse.tiempoMaximo)
                tiempo.text = "Tiempo: " + System.Math.Round((double)textoMorse.tiempoRestante, 2);
            else
                tiempo.text = "Tiempo: " + System.Math.Round((double)textoMorse.contador, 2);

        }
        else
            canvasGO.SetActive(false);
    }
}
