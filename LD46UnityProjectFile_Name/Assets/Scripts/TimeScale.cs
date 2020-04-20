using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScale : MonoBehaviour
{
    public float timeScale = 1;

    void Update()
    {
        if (Time.timeScale == timeScale) return; // purely for easy test funktionality in playmode
        SetTimeScale(timeScale);
    }

    public void SetTimeScale(float time)
    {
        Time.timeScale = time;
    }
}
