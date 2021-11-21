using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuInicio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NJugadores(int i)
    {
        PlayerPrefs.SetInt("PlayersMode", i);
        SceneManager.LoadScene("EscenaBase", LoadSceneMode.Single);
    }

    public void Salir()
    {
        Debug.Log("Salir");
    }

}
