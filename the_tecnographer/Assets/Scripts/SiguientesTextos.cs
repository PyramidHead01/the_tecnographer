using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SiguientesTextos : MonoBehaviour
{

    public int orden;
    textoMorse textoMorse;
    Text texto;

    // Start is called before the first frame update
    void Awake()
    {
        textoMorse = GameObject.Find("ControladorBase").GetComponent<textoMorse>();
        texto = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        if (orden + textoMorse.cabezal < textoMorse.arrayCaracteres.Count)
            texto.text = textoMorse.arrayCaracteres[orden + (int)textoMorse.cabezal].ToString();
        else
            texto.text = "";

    }
}
