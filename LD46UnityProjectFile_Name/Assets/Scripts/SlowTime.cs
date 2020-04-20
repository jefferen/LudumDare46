using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour
{
    public IEnumerator TimeImpact(float startImpact = 0.7f, float lerpDegree = 0.05f) // maybe lerp to the start impact as well, hard to test when only the player moves
    {
        Time.timeScale = startImpact;
        yield return new WaitForSeconds(0.25f);
        while (startImpact <= 1)
        {
            Time.timeScale = startImpact;
            startImpact += lerpDegree;
            yield return new WaitForSeconds(0.1f); // dont make it pr frame because the frame rate can vary and the effect will die off at a changing rate
        }
        Time.timeScale = 1;
    }
}
