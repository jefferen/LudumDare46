using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public GameObject Baby;
    Health hp;
    public float moveSpeed;
    float dist;
    public float followDist;
    Rigidbody2D rb;
    bool willFollow;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hp = GetComponent<Health>();
    }

    void Update()
    {
        dist = Vector2.Distance(transform.position, Baby.transform.position);
        if (dist < 0.45)
        {
            hp.Death();
        }
        if (dist < followDist) willFollow = true;
    }

    public void Taunted()
    {
        if (willFollow) return;
        willFollow = true;
    }

    void FixedUpdate()
    {
        if (willFollow)
        {
            Vector3 dir = Baby.transform.position - transform.position;
            dir.z = 0;
            dir.Normalize();
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            Vector2 v = Baby.transform.position - transform.position;
            v.Normalize();
            rb.velocity = v * moveSpeed;
        }
    }
}
