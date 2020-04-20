using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Health : MonoBehaviour
{
    public string effectTag;
    public int health; 
    public GameObject deadEffect;
    public SlowTime slowTime;
    public int MaxHp;
    public string tag;
    GameObject UI;
    public int offset;
    TMPro.TextMeshProUGUI hpText;
    Image hpImage;

    void Start()
    {
        FullHp();
        UI = GameObject.FindGameObjectWithTag("HP");
        UI = Instantiate(UI, UI.transform.position, Quaternion.identity);
        UI.transform.SetParent(GameObject.FindGameObjectWithTag("Respawn").transform); // this godanm canvas tag change cost me everything
        UI.GetComponent<UIFollow>().GiveTarget(gameObject,offset);
        hpText = UI.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        hpImage = UI.GetComponent<Image>();
        UpdateUI();
    }

    public void FullHp()
    {
        health = MaxHp;
    }

    public void SetHp(int val)
    {
        health = val;
    }
    public void SetFullHp(int val)
    {
        MaxHp = val;
    }

    public void Heal(int val)
    {
        health += val;
        if (health > MaxHp) health = MaxHp; // possible shield effect?
    }

    public void DoDamage(int val)
    {
        health -= val;
        UpdateUI();
        if (tag == "Baby") GameManager.game.PlaySound("cry"); // should just have added a delegate func to it if the tag is baby
        StartCoroutine(slowTime.TimeImpact());
        if (health <= 0) Death();
    }

    public void DoDamage(int val, GameObject hitEffect) // not preatty
    {
        health -= val;
        UpdateUI();
        if (tag == "Baby") GameManager.game.PlaySound("cry"); 
        StartCoroutine(slowTime.TimeImpact()); 
        hitEffect.transform.position = transform.position; 
        hitEffect.SetActive(true);
        if (health <= 0) Death();
        if (!GetComponent<EnemyFollow>()) return;
        GetComponent<EnemyFollow>().Taunted();
    }

    void UpdateUI()
    {
        hpText.text = health.ToString();
        float h = health;
        float hh = MaxHp;
        hpImage.fillAmount = (h / hh);
    }

    public void Death() // disable or destroy object and possible effect
    {
        if (tag == "Baby") GameManager.game.LostGame();
        GameManager.game.objectPool.GetObject(transform.position, transform, effectTag);
        deadEffect.SetActive(true);
        GameManager.game.DepleteEnemies(this);
        this.gameObject.SetActive(false);
        Destroy(UI);
    }

    public IEnumerator HealthTiks(float duration,int val, float TikTimer) // should this even be here?
    {
        while (duration > 0)
        {
            duration -= Time.deltaTime;  // set val to plus or minus from where it is calling from
            health += val;
            yield return new WaitForSeconds(TikTimer);
        }
    }
}
