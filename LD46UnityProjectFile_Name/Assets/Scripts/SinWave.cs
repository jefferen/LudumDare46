using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinWave : MonoBehaviour
{
    public GameObject ball, parent;
    public float moveSpeed, fluctuationHeight, fluctuationDensity;

    void Start()
    {
        StartCoroutine("Sin", 0);
    }

    IEnumerator Sin()
    {
        float x, y;
        x = ball.transform.position.x;
        Vector2 axis = ball.transform.forward;
        Vector2 pos = ball.transform.up;
        parent.transform.Rotate(Vector3.right, 45);
        while (true)
        {
            x += Time.deltaTime * moveSpeed;
            y = Mathf.Sin(x * fluctuationDensity) * fluctuationHeight;
            ball.transform.position = new Vector2(x, y) * axis + pos;

            yield return new WaitForEndOfFrame();
        }
    }
}
