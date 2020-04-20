using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitEffect : MonoBehaviour
{
    public string tag, effectTag;
    public int effectValue;
    GameObject hitEffect;

    void OnCollisionEnter2D(Collision2D other) // if hit, do effect, can be used for object pooling objects that gets disabled, might need rb
    {
        if (other.gameObject.CompareTag(tag))
        {        
            hitEffect = GameManager.game.objectPool.GetObject(effectTag);
            other.gameObject.GetComponent<Health>().DoDamage(effectValue, hitEffect);
            if (gameObject.tag != "SinWave") gameObject.SetActive(false);
        }
        else if(other.gameObject.CompareTag("Environment"))
        {
            GameManager.game.objectPool.GetObject(transform.position, transform, effectTag);
            if (gameObject.tag != "SinWave") gameObject.SetActive(false); // why can´t I get the gameobject from the parent of the sinWave?
        }
    }
}
