using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class IntroSceneManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI dialoge;
    int index = 0;
    void Awake()
    {
        dialoge = GameObject.FindGameObjectWithTag("Dialoge").GetComponent<TMPro.TextMeshProUGUI>();
        DontDestroyOnLoad(this);
        if (index == 0) dialoge.enabled = true;
        index++;
    }

    public void loadScene(int index)
    {
        Debug.Log("Hello");
        SceneManager.LoadScene(index);
    }
}
