using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textoMorse : MonoBehaviour
{

    string texto = ".... --- .-.. .- / -... ..- . -. .- ...";

    public int errores = 0;
    public float contador = 0;
    public double porcentaje = 0;
    public List<char> arrayCaracteres = new List<char>();
    public char caracterActual;
    public float cabezal = 0;
    public bool fin = false;
    public GameObject pantallaResultado, pantallaTextos;
    public Text textoResultado, textPorcentaje, textErroresTotales, textTiempoTotal;

    public bool fallosMaximo = false, tiempoMaximo;
    public float tiempoRestante = 0, tiempoMax = 20;
    public int fallosMax = 5;

    float counArrayTexto;

    // Start is called before the first frame update
    void Start()
    {

        texto = texto.Replace("/", "");
        texto = texto.Replace(" ", "");

        for (int i = 0; i < texto.Length; i++)
        {
            arrayCaracteres.Add(texto[i]);
        }

        counArrayTexto = arrayCaracteres.Count;

    }

    // Update is called once per frame
    void Update()
    {

        if (!fin)
        {
            if (tiempoMax > contador)
            {
                contador += Time.deltaTime;

                tiempoRestante = tiempoMax - contador;
            }

            try
            {
                porcentaje = System.Math.Round((100 / (arrayCaracteres.Count / cabezal)),2);
            }
            catch (System.Exception e)
            {
                porcentaje = 0;
            }
        }





        if (cabezal < arrayCaracteres.Count)
        {
            caracterActual = arrayCaracteres[(int)cabezal];
        }
        else
        {
            Fin();
            //Victoria();
        }

        if ((tiempoRestante <= 0 && tiempoMaximo) || (fallosMaximo && errores >= fallosMax))
        {

            textoResultado.text = "Transcripcion Fallida";

            Fin();
            //Derrota();
        }

    }

    void Fin()
    {
        //Debug.Log("TRANSCRIPCION COMPLETA");

        fin = true;

        pantallaResultado.SetActive(true);
        pantallaTextos.SetActive(false);

        textPorcentaje.text = "Porcentaje completado: " + porcentaje + "%";
        textErroresTotales.text = "Errores totales: " + errores;
        textTiempoTotal.text = "Tiempo total: " + System.Math.Round((double)contador, 2);


    }

    void Victoria()
    {
        Debug.Log("FIN DEL JUEGO BIEN");
    }

    void Derrota()
    {
        Debug.Log("FIN DEL JUEGO MAL");
    }

}
