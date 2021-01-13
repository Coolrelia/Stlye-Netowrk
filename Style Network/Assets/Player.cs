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
    public bool paralyzed;

    public GameObject basicAttackAnim;
    public GameObject swordAnim;
    public GameObject wSwordAnim;
    public GameObject lSwordAnim;
    public GameObject swordSlashPrefab;

    public Animator anim;

    private Vector3 pos;

    StyleMeter sm;

    private void Start()
    {
        sm = FindObjectOfType<StyleMeter>();
    }

    public void Paralyzed()
    {
        StartCoroutine(Paralysis());
    }

    IEnumerator Paralysis()
    {
        paralyzed = true;
        yield return new WaitForSecondsRealtime(2.5f);
        paralyzed = false;
    }

    private void Update()
    {//Movement
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            if (paralyzed == false)
            {
                if (pos.y < topMost)
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        pos.y += 1;
                        transform.position = pos;
                    }

                }
                if (pos.y > bottomMost)
                {
                    if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        pos.y -= 1;
                        transform.position = pos;
                    }
                }
                if (pos.x > leftMost)
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
        }

        //Abilities
        BasicAttack();
        Q();
        W();
        E();
        R();
    }

    void BasicAttack()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 firePosition = transform.position;
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
                    if(enemy.invulnerable == false)
                    {
                        enemy.health -= 10;
                    }
                    else
                    {
                        enemy.health -= 1;
                    }
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
                if (previousAttack == 'Q')
                {
                    previousAttack = 'Q';
                }
                else
                {
                    sm.rank += 1;
                    previousAttack = 'Q';
                }
                Vector2 position = transform.position;
                Instantiate(swordSlashPrefab, position + new Vector2(1, 0), Quaternion.identity);
                sm.StopAllCoroutines();
                sm.StartCoroutine(sm.ResetStyleRank(7));               
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
                if (previousAttack == 'W')
                {
                    previousAttack = 'W';
                }
                else
                {
                    sm.rank += 1;
                    previousAttack = 'W';
                }
                Vector2 position = transform.position;
                Instantiate(swordSlashPrefab, position + new Vector2(1, 0), Quaternion.identity);
                Instantiate(swordSlashPrefab, position + new Vector2(1, 1), Quaternion.identity);
                sm.StopAllCoroutines();
                sm.StartCoroutine(sm.ResetStyleRank(7));
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
                if (previousAttack == 'E')
                {
                    previousAttack = 'E';
                }
                else
                {
                    sm.rank += 1;
                    previousAttack = 'E';
                }
                Vector2 position = transform.position;
                Instantiate(swordSlashPrefab, position + new Vector2(1, 0), Quaternion.identity);
                Instantiate(swordSlashPrefab, position + new Vector2(2, 0), Quaternion.identity);
                Instantiate(swordSlashPrefab, position + new Vector2(3, 0), Quaternion.identity);
                sm.StopAllCoroutines();
                sm.StartCoroutine(sm.ResetStyleRank(7));
            }
        }
    }

    void R()
    {
        if (sm.rank >= 6)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                anim.SetTrigger("BigSword");
                foreach (Enemy enemy in FindObjectsOfType<Enemy>())
                {
                    if (enemy.transform.position.y == transform.position.y && enemy.transform.position.x == transform.position.x + 1 ||
                        enemy.transform.position.y == transform.position.y && enemy.transform.position.x == transform.position.x + 2 ||
                        enemy.transform.position.y == transform.position.y && enemy.transform.position.x == transform.position.x + 3)
                    {

                        if (previousAttack == 'R')
                        {
                            previousAttack = 'R';
                        }
                        else
                        {
                            previousAttack = 'R';
                        }

                        Instantiate(swordAnim, enemy.transform.position, Quaternion.identity);
                        if (enemy.invulnerable == false)
                        {
                            enemy.health -= 200;
                        }
                        else
                        {
                            enemy.health -= 1;
                        }
                        sm.StopAllCoroutines();
                        sm.StartCoroutine(sm.ResetStyleRank(7));
                    }
                }
            }
        }
    }
}
