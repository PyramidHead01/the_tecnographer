using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textoMorse : MonoBehaviour
{

    string texto = ".... --- .-.. .- / -... ..- . -. .- ...";

    public int errores = 0;
    public float contador = 0, tiempoRestante = 0, tiempoMax = 20;
    public List<char> arrayCaracteres = new List<char>();
    public char caracterActual;
    public int cabezal = 0;

    // Start is called before the first frame update
    void Start()
    {

        texto = texto.Replace("/", "");
        texto = texto.Replace(" ", "");

        for (int i = 0; i < texto.Length; i++)
        {
            arrayCaracteres.Add(texto[i]);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if(tiempoMax > contador)
        {
            contador += Time.deltaTime;

            tiempoRestante = tiempoMax - contador;
        }


        if(cabezal <= arrayCaracteres.Count)
            caracterActual = arrayCaracteres[cabezal];
        else
        {
            Victoria();
        }

        if(tiempoRestante <= 0)
        {
            Derrota();
        }

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
