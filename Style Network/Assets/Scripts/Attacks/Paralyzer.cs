using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralyzer : MonoBehaviour
{
    public float speed;
    public int damage;
    public Rigidbody2D rb;

    private void Start()
    {
        rb.velocity = -transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.GetComponent<Player>() != null)
        {
            hitInfo.GetComponent<Animator>().SetTrigger("Damage");
            hitInfo.GetComponent<Player>().health -= damage;
            hitInfo.GetComponent<Player>().Paralyzed();
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible() => Destroy(gameObject);
}
