using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnEnable : MonoBehaviour
{
    public string soundToPlay;
    int index = 0;

    void OnEnable()
    {
        if (index != 0)
        {
            GameManager.game.PlaySound(soundToPlay); // they exist at the start of the scene and gets called right before they can get set to inactive in the pool
        }
        else index++;
    }
}
