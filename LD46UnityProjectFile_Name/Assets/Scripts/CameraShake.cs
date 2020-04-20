using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Vector3 OriginPoint, tempoint; // origin is a local position at 0,0,0 as in the camera must be paranted as it would be in most circumstances
    [Range(0.001f,1)]
    public float shakeStrength; // strength and duration here is for test purpose
    [Range(0.01f,2)]
    public float time;

    public IEnumerator Tremble(float duration, float magnitude) // 2D shake
    {
        float t = 0;
        OriginPoint = transform.localPosition;

        while (t<duration)
        {
            t += Time.deltaTime;
            tempoint = OriginPoint + new Vector3(Random.Range(-magnitude, magnitude), Random.Range(-magnitude, magnitude), 0);
            transform.localPosition = new Vector3(tempoint.x, tempoint.y,transform.localPosition.z); 
            yield return null;
        }
        transform.localPosition = OriginPoint;
    }

    public IEnumerator Shake(float duration, float magnitude) // 3D shake try 2 and 50,  it kinda dies of to fast
    {
        float t = 0;
        while (t<duration)
        {
            Vector3 rotationAmount = Random.insideUnitSphere * magnitude;//A Vector3 to add to the Local Rotation
            rotationAmount.z = 0;//Don't change the Z; it looks funny.

            float shakePercentage = duration / 1;//Used to set the amount of shake (% * startAmount).

            magnitude = 5 * shakePercentage;//Set the amount of shake (% * startAmount).
            duration = Mathf.Lerp(duration, 0, Time.deltaTime);//Lerp the time, so it is less and tapers off towards the end.

           transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(rotationAmount), Time.deltaTime * 2); // smooth 5= smoothamount
           //transform.localRotation = Quaternion.Euler(rotationAmount);//Set the local rotation the be the rotation amount.

            yield return null;
        }
        transform.localRotation = Quaternion.identity;
    }
}
