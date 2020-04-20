using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    public static GameManager game;
    Camera camera;
    public static CameraShake cam;
    public ObjectPooling objectPool;
    AudioSource audioSource;
    public AudioClip pew, cry, hit, explosion;
    bool canCry = true;
    public Image fadeSprite;
    public List<Health> enemies = new List<Health>();
    public TMPro.TextMeshProUGUI winText;

    void Start()
    {
        game = this;
        audioSource = GetComponent<AudioSource>();
        camera = GetComponent<Camera>();
        cam = GetComponent<CameraShake>();
        objectPool = GetComponent<ObjectPooling>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();  
    }

    public void DepleteEnemies(Health hp)
    {
        enemies.Remove(hp);
        if (enemies.Count != 0) return;
        WinGame();
    }

    public void WinGame()
    {
        StartCoroutine(FadeMaterial.fade.Fade(0.8f, fadeSprite, true));
        winText.text = "You succeded";
        Invoke("ReloadLvl", 1.15f);
    }

    public void LostGame() // indicate the player lost, and then reload lvl or reset the lvl as in the first start of the scene will have aditional dialoge
    {
        StartCoroutine(FadeMaterial.fade.Fade(0.8f,fadeSprite,true));
        winText.text = "You died";
        Invoke("ReloadLvl", 1.15f);
    }

    public void ReloadLvl()
    {
        SceneManager.LoadScene(0); // reloads current scene
    }
  
    public void PlaySound(string audioclip)
    {
        if(audioclip == "pew")
        {
            audioSource.PlayOneShot(pew);
        }
        else if(audioclip == "cry" && canCry)
        {
            canCry = false;
            Invoke("CanCryAgain",1.5f);
            audioSource.PlayOneShot(cry);
        }
        else if(audioclip == "explosion")
        {
            audioSource.PlayOneShot(explosion);
        }
        else audioSource.PlayOneShot(hit);
    }

    void CanCryAgain()
    {
        canCry = true;
    }
}