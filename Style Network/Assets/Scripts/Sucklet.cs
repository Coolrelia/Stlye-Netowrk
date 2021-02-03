using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sucklet : Enemy
{
    private bool introDone = false;

    public Text suckletHealth;

    private Vector2 position;

    public Animator anim;

    public GameObject redBomb;
    public GameObject paralyzer;

    GameMaster gm;

    private void Start()
    {
        gm = FindObjectOfType<GameMaster>();
        StartCoroutine(Behavior(11));
    }

    private void Update()
    {
        suckletHealth.text = "HP: " + health.ToString();
        
        if(health <= 0)
        {
            StartCoroutine(Death(0.5f));
        }
    }

    IEnumerator Death(float time)
    {
        yield return new WaitForSecondsRealtime(1f);
        anim.SetBool("Death", true);
        yield return new WaitForSecondsRealtime(time);
        gameObject.SetActive(false);
    }

    IEnumerator Behavior(float time)
    {
        while (health > 0)
        {
            position = transform.position;
            Player player = FindObjectOfType<Player>();
            if(introDone == false)
            {
                yield return new WaitForSecondsRealtime(time);
                introDone = true;
            }
            else
            {
                yield return new WaitForSecondsRealtime(2f);
            }

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
                yield return new WaitForSecondsRealtime(1f);
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

            int color2 = Random.Range(1, 4);

            if (color2 == 1)
            {
                anim.SetBool("RedTransform", true);
                yield return new WaitForSecondsRealtime(2f);
                Instantiate(redBomb, transform.position, Quaternion.identity);
                anim.SetBool("RedTransform", false);
            }
            if (color2 == 2)
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
            if (color2 == 3)
            {
                anim.SetBool("YellowTransform", true);
                yield return new WaitForSecondsRealtime(1f);
                Instantiate(paralyzer, transform.position, Quaternion.identity);
                anim.SetBool("YellowTransform", false);
            }
        }
    }
}
