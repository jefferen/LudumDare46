using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollow : MonoBehaviour
{
    Camera cam;
    GameObject target;
    int offset;

    void Awake() 
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public void GiveTarget(GameObject t, int o)
    {
        target = t;
        offset = o;
    }

    void FixedUpdate()
    {
        if (!target) return;
        Vector2 screenPos = cam.WorldToScreenPoint(target.transform.position);
        transform.position = screenPos + new Vector2(0,offset);
    }
}
