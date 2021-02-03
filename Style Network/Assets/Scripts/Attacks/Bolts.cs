using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolts : MonoBehaviour
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
                IncreaseRank();
                Destroy(gameObject);
            }
            else
            {
                hitInfo.GetComponent<Enemy>().health -= 1;
                IncreaseRank();
                Destroy(gameObject);
            }
        }
    }

    void IncreaseRank()
    {
        if (transform.parent.GetComponent<Player>().previousAttack == 'B')
        {
            transform.parent.GetComponent<Player>().previousAttack = 'B';
        }
        else
        {
            sm.rank += 1;
            transform.parent.GetComponent<Player>().previousAttack = 'B';
        }
    }

    void OnBecameInvisible() => Destroy(gameObject);

}
