using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class botonBase : MonoBehaviour, IUpdateSelectedHandler, IPointerDownHandler, IPointerUpHandler
{

    #region Variables

    #region Basicas
    public bool seEstaPulsando = false, mantener = false;
    public float tiempo = 0, limite = 0.5f;
    #endregion

    #region Sonidos
    AudioSource sourceSonido;
    public AudioClip sonidoCorto, sonidoLargo;
    #endregion

    #region Scrips Auxiliares
    textoMorse textoMorse;
    #endregion

    #endregion

    #region Accion Pulsar O Mantener
    void Pulsar()
    {
        //Debug.Log("Click");

        sourceSonido.PlayOneShot(sonidoCorto);

        if (textoMorse.caracterActual == '.')
        {

            Resultado();

        }
        else
        {
            Fallo();
        }

    }

    void Mantener()
    {
        //Debug.Log("Mantienes pulsado");

        sourceSonido.PlayOneShot(sonidoLargo);

        if (textoMorse.caracterActual == '-')
        {
            Resultado();

        }
        else
        {
            Fallo();
        }

    }

    void Fallo()
    {
        textoMorse.errores++;
    }

    void Resultado()
    {
        textoMorse.cabezal++;
    }

    #endregion

    #region Voids Basicos

    void Awake()
    {
        sourceSonido = this.GetComponent<AudioSource>();
        textoMorse = GameObject.Find("ControladorBase").GetComponent<textoMorse>();
    }

    public void OnUpdateSelected(BaseEventData data)
    {

        //Si estamos pulsando la variable tiempo aumentara cada segundo
        #region Se Esta Pulsando
        if (seEstaPulsando)
            tiempo += Time.deltaTime;
        #endregion

        //Si ha transcurrido un tiempo concreto, este entendera que estas manteniendo pulsado, pero como queremos que solo ejecute el metodo 1 vez lo que hara sera
        //que compruebe si una variable esta en negativo, y al acabar esta condicion, esta se pondra positiva, de modo que da igual el tiempo que pase
        //no va a volver a esa condicion
        #region Mantener?
        if (tiempo >= limite)
        {
            if(!mantener)
                Mantener();

            mantener = true;

        }
        #endregion

    }
   
    #endregion

    #region Pulsar Y Soltar

    //Esto sirve para detectar si hemos pulsado un boton, solo pulsarlo
    public void OnPointerDown(PointerEventData data)
    {
        seEstaPulsando = true;
    }

    //Esto sirve para comprobar cuando levantamos el boton
    public void OnPointerUp(PointerEventData data)
    {
        //Estas dos variables booleanas necesitan que sean falsas para el futuro
        #region Setear A False
        seEstaPulsando = false;
        mantener = false;
        #endregion

        //Si ha pasado menos tiempo del pensado entonces se activa el click
        #region Click?
        if (tiempo < limite)
        {
            Pulsar();
        }
        #endregion

        //Seteamos el tiempo a 0, ahora y no antes para que la condicion de comprobar si es click se cumpla
        #region Setar Tiempo
        tiempo = 0;
        #endregion

    }

    #endregion
}
