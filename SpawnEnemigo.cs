using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemigo : MonoBehaviour
{
    public GameObject Enemigo;
    public float Cooldown;
    float Cuenta_atras;
    public Transform[] posiciones;

    void Update()
    {
        //Constuimos una cuenta atras que cuando llegue a 0, instancia un enemigo y el valor regresa a un Cooldown que va disminuyendo cada enemigo que instancia.
        //Con esto conseguimos que instancie cada vez mas rapido y aumente la dificultad.
        if (Cuenta_atras <=0)
        {
            Instanciar();
            Cuenta_atras = Cooldown;
        }

        else
        {
            Cuenta_atras -= Time.deltaTime;
        }
    }

    void Instanciar()
    {
        Instantiate(Enemigo, posiciones[Random.Range(0, posiciones.Length)].position, Quaternion.identity);

        if (Cooldown > 0.8f)
        {
            //con esto el contador disminuye con el tiempo
            Cooldown *= 0.95f;
        }

    }
}

