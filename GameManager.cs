using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public GameObject Pausa;

    //Botones UI

    public void Continuar()
    {
        Time.timeScale = 1f;
        Pausa.SetActive(false);
        FindObjectOfType<Meta>().juegopausado = false;
    }

    public void menu()
    {
        Time.timeScale = 1f;
        Pausa.SetActive(false);
        SceneManager.LoadScene("Menu");
    }

    public void Reset()
    {

        Time.timeScale = 1f;
        Pausa.SetActive(false);
        SceneManager.LoadScene("Juego");
    }
}
