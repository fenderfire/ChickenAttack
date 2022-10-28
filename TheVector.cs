using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheVector 
{

    public float x;
    public float y;
    public float z;

    #region Constructores

    public TheVector()
    {
        x = 0;
        y = 0;
        z = 0;
    }

    public TheVector(float _x, float _y, float _z)
    {
        x = _x;
        y = _y;
        z = _z;
    }


    #endregion Constructores

    public Vector3 tovector3()
    { 
      return new Vector3(x, y, z); 
    }
}
