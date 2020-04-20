using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveDmg : MonoBehaviour
{
    public int effectValue;

    void OnCollisionEnter2D(Collision2D other) // if hit, do effect, can be used for object pooling objects that gets disabled, might need rb
    {
        if (other.gameObject.CompareTag("KeepItSafe"))
        {
            other.gameObject.GetComponent<Health>().DoDamage(effectValue);
        }
    }
}
