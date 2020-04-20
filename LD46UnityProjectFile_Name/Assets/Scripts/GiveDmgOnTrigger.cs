using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveDmgOnTrigger : MonoBehaviour
{
    public int effectValue;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("KeepItSafe")) return;
        other.gameObject.GetComponent<Health>().DoDamage(effectValue);
    }
}
