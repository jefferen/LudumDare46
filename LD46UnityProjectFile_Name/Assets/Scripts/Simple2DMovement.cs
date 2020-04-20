using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simple2DMovement : MonoBehaviour
{
    float h, v;
    [Range(1,100)]
    public float moveSpeed;
    public CameraShake camShake;
    public GameObject firepoint, f1,f2,f3;
    Rigidbody2D rb;
    float sin, fire;
    public TMPro.TextMeshProUGUI sinText;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        dir.z = 0;
        dir.Normalize();
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && fire == 0) // normal fire
        {
            fire = 3;
            StartCoroutine(CanFireAb(0, 0.1f));
            rb.AddForce(transform.right * -100000f); // the player has no drag, why does it need such a big force, and why does it stop so suddenly?
            GameManager.game.objectPool.GetObject(firepoint.transform.position, transform,"FireProjectile");
            GameManager.game.PlaySound("pew");
        }
        if (Input.GetKeyDown(KeyCode.Q) && sin == 0) 
        {
            sin = 1;
            StartCoroutine(CanFireAb(1, 4));
            rb.AddForce(transform.right * -500000f);
            GameManager.game.objectPool.GetObject(firepoint.transform.position, transform, "SinWave");
            GameManager.game.PlaySound("pew");
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) // shield, drop and pickup
        {

        }
    }

    IEnumerator CanFireAb(int index, float cooldown)
    {
        while (cooldown >= 0)
        {
            cooldown -= Time.deltaTime;
            if (index == 1) sinText.text = cooldown.ToString("F1");
            yield return new WaitForEndOfFrame();
        }
        if (index == 1)
        {
            sin = 0;
            sinText.text = "".ToString();
        }
        fire = 0;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(h, v).normalized * moveSpeed;
    }
}
