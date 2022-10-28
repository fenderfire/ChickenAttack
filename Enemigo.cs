using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float damage;
    public float Velocidad;

    public GameObject Particula;
    public GameObject Particula2;

    public AudioClip MuerteSound;
    public AudioClip ExplosionSound;

    void Update()
    {
        transform.position += new Vector3(0, 0, Velocidad) * Time.deltaTime;
    }

    public void OnTriggerEnter(Collider other)
    {
        //Colisiona con la meta
        if (other.GetComponent<Meta>() != null)
        {
            FindObjectOfType<AudioManager>().PlaySound(ExplosionSound);
            Instantiate(Particula, transform.position, Quaternion.identity);
            other.GetComponent<Meta>().TakeDamage(damage);
            Destroy(gameObject);
        }

        //Colisiona con la bala
        if (other.CompareTag("Bala"))
        {
            Instantiate(Particula2, transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().PlaySound(MuerteSound);
            FindObjectOfType<Meta>().Addbajas();
            Destroy(gameObject);

        }
    }


}
