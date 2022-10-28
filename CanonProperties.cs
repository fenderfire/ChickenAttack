using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonProperties : MonoBehaviour
{
    public List<GameObject> Lista = new List<GameObject>();
    public GameObject bala;


    #region Variables

    //Referencias
    public GameObject Canon;
    public GameObject Spawner_Canon;
    public GameObject Eje;
    

    //Parametros de la bala
    public float Vm;
    public float Alpha;
    public float Gamma;
    public float Gravedad; 
    public float Tinc; 


    //Parametros del cañon
    public float L;
    public float Lx;
    public float Ly;
    public float Lz;

    //Cosenos directores
    float Omegax;
    float Omegay;
    float Omegaz;

    //Simulation
    public float Yb;
    public float b;

    public AudioClip DisparoSound;

    #endregion


    void Update()
    {
        Alpha = Eje.transform.localEulerAngles.x +90;
        Gamma = Eje.transform.localEulerAngles.y +270;
       
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Instanciar();
            FindObjectOfType<AudioManager>().PlaySound(DisparoSound);
        }

        Disparo();
    }

    #region funciones

    public void Disparo()
    {
        for(int i = 0; i < Lista.Count; i++)
        {
            GameObject Proyectil = Lista[i];
            TheVector Position = Simulation(Proyectil.GetComponent<Bala>(), Time.deltaTime);

            if (Proyectil.GetComponent<Bala>().Tinc_Bala >= 4)
            {
                Lista.Remove(Proyectil);
                Destroy(Proyectil);
            }

            else
            {
                Proyectil.transform.position = Position.tovector3();
            }
        }

    }

    public void Instanciar()
    {
        GameObject clon = Instantiate(bala);

        clon.GetComponent<Bala>().Alpha_Bala = Alpha;
        clon.GetComponent<Bala>().Gamma_Bala = Gamma;
        clon.GetComponent<Bala>().Gravedad_Bala = Gravedad;
        clon.GetComponent<Bala>().Tinc_Bala = Tinc;
        clon.GetComponent<Bala>().posInit = Spawner_Canon.transform.position;
        clon.GetComponent<Bala>().Vm_Bala = Vm;

        Lista.Add(clon);
    }

    public TheVector Simulation(Bala Proyectil, float dTime)
    {
        b = L * Mathf.Cos((90 - Proyectil.Alpha_Bala) * (Mathf.PI / 180f));
        Lz = b * Mathf.Cos((Proyectil.Gamma_Bala) * (Mathf.PI / 180f));
        Ly = L * Mathf.Cos((Proyectil.Alpha_Bala) * (Mathf.PI / 180f));
        Lx = b * Mathf.Sin((Proyectil.Gamma_Bala) * (Mathf.PI / 180f));

        Omegax = Lx / L;
        Omegay = Ly / L;
        Omegaz = Lz / L;

        TheVector u = new TheVector();
        
        float Vx = Proyectil.Vm_Bala * Omegax;
        float Vy = Proyectil.Vm_Bala * Omegay;
        float Vz = Proyectil.Vm_Bala * Omegaz;

        Proyectil.Tinc_Bala += dTime;

        u.x = Proyectil.posInit.x + (Proyectil.Vm_Bala * Omegax) * Proyectil.Tinc_Bala;
        u.y = (Yb + Proyectil.posInit.y) + (Proyectil.Vm_Bala * Omegay) * Proyectil.Tinc_Bala - 1f / 2f * Proyectil.Gravedad_Bala * Mathf.Pow(Proyectil.Tinc_Bala, 2f);
        u.z = Proyectil.posInit.z + (Proyectil.Vm_Bala * Omegaz) * Proyectil.Tinc_Bala;


        return u;
    }

    #endregion
}
