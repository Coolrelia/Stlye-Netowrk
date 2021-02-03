using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBombExplosion : MonoBehaviour
{
    public float lifetime;

    private void Start()
    {
        Invoke("Destruction", lifetime);
    }

    void Destruction()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        hitInfo.GetComponent<Animator>().SetTrigger("Damage");
        hitInfo.GetComponent<Player>().health -= 20;
        Destroy(gameObject);
    }
}
