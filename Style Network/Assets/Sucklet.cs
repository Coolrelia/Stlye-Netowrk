using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sucklet : Enemy
{
    private Vector2 position;

    public Animator anim;

    public GameObject redBomb;
    public GameObject paralyzer;

    private void Start()
    {
        StartCoroutine(Behavior(3));
    }

    IEnumerator Behavior(float time)
    {
        while(health > 0)
        {
            position = transform.position;
            Player player = FindObjectOfType<Player>();
            yield return new WaitForSecondsRealtime(time);

            //Moves up 2 tiles
            if (position.y < 2)
            {
                position.y = position.y + 1;
            }
            transform.position = position;
            yield return new WaitForSecondsRealtime(1f);

            if (position.y < 2)
            {
                position.y = position.y + 1;
            }
            transform.position = position;
            yield return new WaitForSecondsRealtime(1f);

            int color = Random.Range(1, 4);

            if(color == 1)
            {
                anim.SetBool("RedTransform", true);
                yield return new WaitForSecondsRealtime(2f);
                Instantiate(redBomb, transform.position, Quaternion.identity);
                anim.SetBool("RedTransform", false);
            }
            if (color == 2)
            {
                anim.SetBool("BlueTransform", true);
                yield return new WaitForSecondsRealtime(2f);
                position = new Vector2(0, 1);
                transform.position = position;
                invulnerable = true;
                yield return new WaitForSecondsRealtime(3f);
                invulnerable = false;
                yield return new WaitForSecondsRealtime(1.5f);
                position = new Vector2(2, 0);
                transform.position = position;
                anim.SetBool("BlueTransform", false);
            }
            if (color == 3)
            {
                anim.SetBool("YellowTransform", true);
                yield return new WaitForSecondsRealtime(2f);
                Instantiate(paralyzer, transform.position, Quaternion.identity);
                anim.SetBool("YellowTransform", false);
            }

            yield return new WaitForSecondsRealtime(1f);
            //Moves down 2 tiles
            if (position.y > 0)
            {
                position.y = position.y - 1;
            }
            transform.position = position;
            yield return new WaitForSecondsRealtime(1f);

            if (position.y > 0)
            {
                position.y = position.y - 1;
            }
            transform.position = position;

            if (color == 1)
            {
                anim.SetBool("RedTransform", true);
                yield return new WaitForSecondsRealtime(2f);
                Instantiate(redBomb, transform.position, Quaternion.identity);
                anim.SetBool("RedTransform", false);
            }
            if (color == 2)
            {
                anim.SetBool("BlueTransform", true);
                yield return new WaitForSecondsRealtime(2f);
                position = new Vector2(0, 1);
                transform.position = position;
                invulnerable = true;
                yield return new WaitForSecondsRealtime(3f);
                invulnerable = false;
                yield return new WaitForSecondsRealtime(1.5f);
                position = new Vector2(2, 0);
                transform.position = position;
                anim.SetBool("BlueTransform", false);
            }
            if (color == 3)
            {
                anim.SetBool("YellowTransform", true);
                yield return new WaitForSecondsRealtime(2f);
                Instantiate(paralyzer, transform.position, Quaternion.identity);
                anim.SetBool("YellowTransform", false);
            }
        }
    }
}
