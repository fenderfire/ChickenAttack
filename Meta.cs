using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Meta : MonoBehaviour
{
    #region variables
    //Vida UI
    public Image Barra_Damage;
    public float Vida;
    public float Max_Vida;
    
    //TiempoUI
    public float time;
    public TextMeshProUGUI tiempoUI;

    //BajasUI
    public float bajas;
    public TextMeshProUGUI bajasUI;

    //Canvas
    [HideInInspector] public GameObject Game_Over;
    [HideInInspector] public GameObject Pausa;
    [HideInInspector]public bool juegopausado;

    public bool God_Mode;
    #endregion

    void Start()
    {
        bajasUI.text = bajas.ToString();
        Barra_Damage.fillAmount = 1; 
    }


    void Update()
    {
        pausa();
        time += Time.deltaTime;
        tiempoUI.text = time.ToString("0");
        GodMode();
    }

    //Restar 1 de vida cuando el pollo choca con la meta
    public void TakeDamage(float Damage)
    {
        Vida -= Damage;
        Barra_Damage.fillAmount = Vida / Max_Vida;
        Debug.Log("Daño");


        if (Vida <= 0)
        {
            Game_Over.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    //Vida infinita para probar mecanicas sin morir
    public void GodMode()
    {
        if (God_Mode == true)
        {
            Vida = 100000;
        }
    }

    public void Addbajas()
    {
        bajas++;
        bajasUI.text = bajas.ToString();
    }

    public void pausa()
    {
        if ((Input.GetKeyDown(KeyCode.Escape)))
        {
            if (juegopausado == false)
            {
                Time.timeScale = 0f;
                Pausa.SetActive(true);
                juegopausado = true;

            }

            else
            {
                Time.timeScale = 1f;
                Pausa.SetActive(false);
                juegopausado = false;
            }
        }

    }
}
