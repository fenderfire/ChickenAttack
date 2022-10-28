using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{

    public TextMeshProUGUI Stats_tiempo;
    public TextMeshProUGUI Stats_Bajas;

    void Start()
    {
        Stats_Bajas.text = FindObjectOfType<Meta>().bajas.ToString();
        Stats_tiempo.text = FindObjectOfType<Meta>().time.ToString("0");
    }
}
