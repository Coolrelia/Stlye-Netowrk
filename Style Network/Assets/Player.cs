using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int topMost;
    public int bottomMost;
    public int leftMost;
    public int rightMost;

    public int health;
    public char previousAttack;

    public GameObject basicAttackAnim;
    public GameObject swordAnim;
    public GameObject wSwordAnim;
    public GameObject lSwordAnim;

    public Animator anim;

    private Vector3 pos;

    StyleMeter sm;

    private void Start()
    {
        sm = FindObjectOfType<StyleMeter>();
    }

    private void Update()
    {
        //Abilities
        BasicAttack();
        Q();
        W();
        E();
        R();


        //Movement 
        if(pos.y < topMost)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                pos.y += 1;
                transform.position = pos;
            }

        }
        if(pos.y > bottomMost)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                pos.y -= 1;
                transform.position = pos;
            }
        }
        if(pos.x > leftMost)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                anim.SetTrigger("Left");
                pos.x -= 1;
                transform.position = pos;
            }
        }
        if (pos.x < rightMost)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                anim.SetTrigger("Right");
                pos.x += 1;
                transform.position = pos;
            }
        }
    }

    void BasicAttack()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("BasicAttack");
            foreach(Enemy enemy in FindObjectsOfType<Enemy>())
            {
                if(transform.position.y == enemy.transform.position.y)
                {
                    if(previousAttack == 'B')
                    {
                        previousAttack = 'B';
                    }
                    else
                    {
                        sm.rank += 1;
                        previousAttack = 'B';
                    }

                    Instantiate(basicAttackAnim, enemy.transform.position, Quaternion.identity);
                    enemy.health -= 10;
                    sm.StopAllCoroutines();
                    sm.StartCoroutine(sm.ResetStyleRank(7));
                }
            }
        }
    }

    void Q()
    {
        if(sm.rank >= 1)
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                anim.SetTrigger("Sword");
                foreach (Enemy enemy in FindObjectsOfType<Enemy>())
                {
                    if(enemy.transform.position.x == transform.position.x + 1 && enemy.transform.position.y == transform.position.y)
                    {

                        if (previousAttack == 'Q')
                        {
                            previousAttack = 'Q';
                        }
                        else
                        {
                            sm.rank += 1;
                            previousAttack = 'Q';
                        }

                        Instantiate(swordAnim, enemy.transform.position, Quaternion.identity);
                        enemy.health -= 50;
                        sm.StopAllCoroutines();
                        sm.StartCoroutine(sm.ResetStyleRank(7));
                    }
                }
            }
        }
    }

    void W()
    {
        if(sm.rank >= 2)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                anim.SetTrigger("Sword");
                foreach (Enemy enemy in FindObjectsOfType<Enemy>())
                {
                    if (enemy.transform.position.y == transform.position.y && enemy.transform.position.x == transform.position.x + 1 ||
                        enemy.transform.position.y == transform.position.y + 1 && enemy.transform.position.x == transform.position.x + 1 ||
                        enemy.transform.position.y == transform.position.y - 1 && enemy.transform.position.x == transform.position.x + 1)
                    {
                        if (previousAttack == 'W')
                        {
                            previousAttack = 'W';
                        }
                        else
                        {
                            sm.rank += 1;
                            previousAttack = 'W';
                        }

                        Instantiate(wSwordAnim, enemy.transform.position, Quaternion.identity);
                        enemy.health -= 80;
                        sm.StopAllCoroutines();
                        sm.StartCoroutine(sm.ResetStyleRank(7));
                    }
                }
            }
        }
    }

    void E()
    {
        if(sm.rank >= 4)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.SetTrigger("Sword");
                foreach (Enemy enemy in FindObjectsOfType<Enemy>())
                {
                    if (enemy.transform.position.y == transform.position.y && enemy.transform.position.x == transform.position.x + 1 ||
                        enemy.transform.position.y == transform.position.y && enemy.transform.position.x == transform.position.x + 2)
                    {
                        if (previousAttack == 'E')
                        {
                            previousAttack = 'E';
                        }
                        else
                        {
                            sm.rank += 1;
                            previousAttack = 'E';
                        }

                        Instantiate(lSwordAnim, enemy.transform.position, Quaternion.identity);
                        enemy.health -= 100;
                        sm.StopAllCoroutines();
                        sm.StartCoroutine(sm.ResetStyleRank(7));
                    }
                }
            }
        }
    }

    void R()
    {
        if (sm.rank >= 5)
        {

        }
    }
}
