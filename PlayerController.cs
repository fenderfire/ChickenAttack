using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 10;
    public float Rotate_Speed = 50;

    public GameObject Eje;

    private Vector2 Limites;

    void Update()
    {
        moverCanon(); 
        Move_Horizontal();
        Move_Vertical();

        //Clampear movimiento rail del cañon
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, -93, 93));
    }

    //Movimiento vertical del cañon
    public void Move_Vertical()
    {
        Vector3 Rotacion_y = Eje.transform.eulerAngles;

        if (Input.GetKey(KeyCode.A))
        {
            Rotacion_y.y -= Rotate_Speed * Time.deltaTime;
            Limites.y -= Rotate_Speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Rotacion_y.y += Rotate_Speed * Time.deltaTime;
            Limites.y += Rotate_Speed * Time.deltaTime;
        }
        
        //Clamp
        if (Limites.y > 45)
        {
            Limites.y = 45;
            Rotacion_y.y = 45;
        }
        else if (Limites.y < -45)
        {
            Limites.y = -45;
            Rotacion_y.y = 360 - 45;
        }

        Eje.transform.eulerAngles = Rotacion_y;
    }

    //Movimiento horizontal del cañon
    public void Move_Horizontal()
    {
        Vector3 Rotacion_z = Eje.transform.eulerAngles;

        if (Input.GetKey(KeyCode.S))
        {
            Rotacion_z.z += Rotate_Speed * Time.deltaTime;
            Limites.x += Rotate_Speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W))
        {
            Rotacion_z.z -= Rotate_Speed * Time.deltaTime;
            Limites.x -= Rotate_Speed * Time.deltaTime;
        }

        //Clamp
        if (Limites.x > 45)
        {
            Limites.x = 45;
            Rotacion_z.z = 45;
        }
        else if (Limites.x < -45)
        {
            Limites.x = -45;
            Rotacion_z.z = 360 - 45;
        }

        Eje.transform.eulerAngles = Rotacion_z;
    }

    //Mover cañon sobre un rail
    public void moverCanon()
    {
        float move = Input.GetAxis("Horizontal");
        transform.position += new Vector3(0, 0, move) * Time.deltaTime * Speed;
    }
}
