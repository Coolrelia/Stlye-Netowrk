using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
    private Vector2 position;
    
    void Start()
    {
        StartCoroutine(Behavior(3));
    }

    void Update()
    {
        if(health <= 0)
        {

        }
    }

    IEnumerator Behavior(float time)
    {
        while(health > 0)
        {
            position = transform.position;
            Player player = FindObjectOfType<Player>();
            yield return new WaitForSecondsRealtime(time);

            //Moves up 2 tiles
            if(position.y < 2)
            {
                position.y = position.y + 1;
            }
            transform.position = position;
            yield return new WaitForSecondsRealtime(1f);

            if(position.y < 2)
            {
                position.y = position.y + 1;
            }
            transform.position = position;
            yield return new WaitForSecondsRealtime(2f);

            //Jumps to players Y coordinate
            position.y = FindObjectOfType<Player>().transform.position.y;
            transform.position = position;
            yield return new WaitForSecondsRealtime(0.5f);

            //Attacks + Move back one tile
            if (player.transform.position.y == transform.position.y)
            {
                player.anim.SetTrigger("Damage");
                player.health -= damage;
                if (position.x > 0)
                {
                    position.x = position.x - 1;
                }
                transform.position = position;
            }
            else
            {
                if (position.x > 0)
                {
                    position.x = position.x - 1;
                }
                transform.position = position;
            }
        }
    }
}
