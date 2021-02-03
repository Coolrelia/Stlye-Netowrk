using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeegBolt : MonoBehaviour
{
    public Rigidbody2D rb;

    public float speed;
    public int damage;
    StyleMeter sm;

    private void Start()
    {
        sm = FindObjectOfType<StyleMeter>();
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.GetComponent<Enemy>() != null)
        {
            if (hitInfo.GetComponent<Enemy>().invulnerable == false)
            {
                hitInfo.GetComponent<Enemy>().health -= damage;
                ResetRank();
                Destroy(gameObject);
            }
            else
            {
                hitInfo.GetComponent<Enemy>().health -= 1;
                ResetRank();
                Destroy(gameObject);
            }
        }
    }

    void ResetRank()
    {
        if (transform.parent.GetComponent<Player>().previousAttack == 'R')
        {
            transform.parent.GetComponent<Player>().previousAttack = 'R';
        }
        else
        {
            sm.rank = 0;
            transform.parent.GetComponent<Player>().previousAttack = 'R';
        }
    }

    void OnBecameInvisible() => Destroy(gameObject);
}
