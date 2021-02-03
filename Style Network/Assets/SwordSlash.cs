﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSlash : MonoBehaviour
{
    public int damage;
    public float lifetime;
    StyleMeter sm;
    Player player;

    private void Start()
    {
        sm = FindObjectOfType<StyleMeter>();
        Invoke("Destruction", lifetime);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.GetComponent<Enemy>() != null)
        {
            if (hitInfo.GetComponent<Enemy>().invulnerable == false)
            {
                hitInfo.GetComponent<Enemy>().health -= 50;
            }
            else
            {
                hitInfo.GetComponent<Enemy>().health -= 1;
            }
        }
    }

    void Destruction()
    {
        Destroy(gameObject);
    }
}
