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

    public Animator anim;

    private Vector3 pos;

    StyleMeter sm;

    private void Start()
    {
        sm = FindObjectOfType<StyleMeter>();
        InvokeRepeating("ResetPreviousAttack", 0f, 5f);
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
                pos.x -= 1;
                transform.position = pos;
            }
        }
        if (pos.x < rightMost)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                pos.x += 1;
                transform.position = pos;
            }
        }
    }

    void ResetPreviousAttack()
    {
        previousAttack = '0';
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
                    if (previousAttack == 'B')
                    {
                        sm.rank -= 1;
                    }
                    else
                    {
                        sm.rank += 1;
                    }
                    previousAttack = 'B';
                    enemy.health -= 10;
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
                            sm.rank -= 1;
                        }
                        else
                        {
                            sm.rank += 1;
                        }
                        previousAttack = 'Q';
                        enemy.health -= 50;
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
                    if(enemy.transform.position.y == transform.position.y && enemy.transform.position.x == transform.position.x + 1 ||
                        enemy.transform.position.y == transform.position.y && enemy.transform.position.x == transform.position.x + 2)
                    {
                        if (previousAttack == 'W')
                        {
                            sm.rank -= 1;
                        }
                        else
                        {
                            sm.rank += 1;
                        }
                        previousAttack = 'W';
                        enemy.health -= 80;
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
                    if(enemy.transform.position.y == transform.position.y && enemy.transform.position.x == transform.position.x + 1 ||
                       enemy.transform.position.y == transform.position.y + 1 && enemy.transform.position.x == transform.position.x + 1 ||
                       enemy.transform.position.y == transform.position.y - 1 && enemy.transform.position.x == transform.position.x + 1)
                    {
                        if (previousAttack == 'E')
                        {
                            sm.rank -= 1;
                        }
                        else
                        {
                            sm.rank += 1;
                        }
                        previousAttack = 'E';
                        enemy.health -= 100;
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
