using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSlash : MonoBehaviour
{
    public int damage;
    public float lifetime;
    StyleMeter sm;

    private void Start()
    {
        sm = FindObjectOfType<StyleMeter>();
        Invoke("Destruction", lifetime);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.GetComponent<Enemy>() != null)
        {
            if (hitInfo.GetComponent<Enemy>().invulnerable == false)
            {
                hitInfo.GetComponent<Enemy>().health -= damage;
                IncreaseRank();
            }
            else
            {
                hitInfo.GetComponent<Enemy>().health -= 1;
                IncreaseRank();
            }
        }
    }

    void IncreaseRank()
    {
        if (transform.parent.GetComponent<Player>().previousAttack == 'Q')
        {
            transform.parent.GetComponent<Player>().previousAttack = 'Q';
        }
        else
        {
            sm.rank += 1;
            transform.parent.GetComponent<Player>().previousAttack = 'Q';
        }
    }

    void Destruction()
    {
        Destroy(gameObject);
    }
}
