using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Controles;

    public void Start()
    {
        Menu.SetActive(true);
        Controles.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            VolverMenu();
        }
    }
    public void StartGame()
    {

        Time.timeScale = 1f;
        SceneManager.LoadScene("Juego");
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void controles()
    {
        Controles.SetActive(true);
        Menu.SetActive(false);
    }

    public void VolverMenu()
    {
        Menu.SetActive(true);
        Controles.SetActive(false);
    }
}
