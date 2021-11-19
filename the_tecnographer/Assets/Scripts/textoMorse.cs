using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textoMorse : MonoBehaviour
{

    string texto = ".... --- .-.. .- / -... ..- . -. .- ...";

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
        caracterActual = arrayCaracteres[cabezal];
    }
}
