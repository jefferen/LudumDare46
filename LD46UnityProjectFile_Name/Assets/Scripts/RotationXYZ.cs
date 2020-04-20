using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationXYZ : GameManager
{
    public float rotation;
    public enum axis { X, Y, Z }
    public axis orientation;

    void Start()
    {
        Vector3 v = new Vector3(0,0,0); // not ideal but ok, what use does this have in the grand scheme of things?
        switch (orientation)
        {
            case axis.X:
                v = Vector3.right;
                break;
            case axis.Y:
                v = Vector3.up;
                break;
            case axis.Z:
                v = Vector3.forward;
                break;
        }
        StartCoroutine(Rotation(v));
    }

    IEnumerator Rotation(Vector3 v)
    {
        while (true)
        {
            transform.Rotate(v, rotation);
            yield return null;
        }          
    }
}
