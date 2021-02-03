using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text playerHealth;
    public GameObject paralysisText;

    public Transform firePoint;

    public float qCooldown;
    private float nextQ = 0;

    public float wCooldown;
    private float nextW = 0;

    public float eCooldown;
    private float nextE = 0;

    public int topMost;
    public int bottomMost;
    public int leftMost;
    public int rightMost;

    public int health;
    public char previousAttack;
    public bool paralyzed;

    public GameObject basicBoltPrefab;
    public GameObject swordSlashPrefab;
    public GameObject wideSwordSlashPrefab;
    public GameObject longSwordSlashPrefab;
    public GameObject beegBoltPrefab;

    public Animator anim;

    private Vector3 pos;

    StyleMeter sm;

    private void Start()
    {
        sm = FindObjectOfType<StyleMeter>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            StartCoroutine(Death());
        }

        if(paralyzed == true)
        {
            paralysisText.SetActive(true);
        }
        else
        {
            paralysisText.SetActive(false);
        }

        playerHealth.text = "HP: " + health.ToString();

        //Movement
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
        StartCoroutine(BasicAttack());
        Q();
        W();
        E();
        StartCoroutine(R());
    }

    IEnumerator BasicAttack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(GameObject.Find("BasicBolt(Clone)"))
            {
                Debug.Log("I exist");
            }
            else
            {
                Vector2 position = transform.position;
                anim.SetTrigger("BasicAttack");

                yield return new WaitForSecondsRealtime(0.2f);
                Instantiate(basicBoltPrefab, firePoint.transform.position, Quaternion.identity, transform);
                sm.StopAllCoroutines();
                sm.StartCoroutine(sm.ResetStyleRank(7));
            }
        }
    }

    void Q()
    {
        if(Time.time > nextQ)
        {
            if (sm.rank >= 1)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    anim.SetTrigger("Sword");
                    Vector2 position = transform.position;
                    Instantiate(swordSlashPrefab, position + new Vector2(1, 0), Quaternion.identity, transform);
                    sm.StopAllCoroutines();
                    sm.StartCoroutine(sm.ResetStyleRank(7));
                    nextQ = Time.time + qCooldown;
                }
            }
        }
    }

    void W()
    {
        if(Time.time > nextW)
        {
            if (sm.rank >= 2)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    anim.SetTrigger("Sword");
                    Vector2 position = transform.position;
                    Instantiate(wideSwordSlashPrefab, position + new Vector2(1, 0), Quaternion.identity, transform);
                    Instantiate(wideSwordSlashPrefab, position + new Vector2(1, 1), Quaternion.identity, transform);
                    sm.StopAllCoroutines();
                    sm.StartCoroutine(sm.ResetStyleRank(7));
                    nextW = Time.time + wCooldown;
                }
            }
        }
    }

    void E()
    {
        if(Time.time > nextE)
        {
            if (sm.rank >= 4)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    anim.SetTrigger("Sword");
                    Vector2 position = transform.position;
                    Instantiate(longSwordSlashPrefab, position + new Vector2(1, 0), Quaternion.identity, transform);
                    Instantiate(longSwordSlashPrefab, position + new Vector2(2, 0), Quaternion.identity, transform);
                    Instantiate(longSwordSlashPrefab, position + new Vector2(3, 0), Quaternion.identity, transform);
                    sm.StopAllCoroutines();
                    sm.StartCoroutine(sm.ResetStyleRank(7));
                    nextE = Time.time + eCooldown;
                }
            }
        }
    }

    IEnumerator R()
    {
        if (sm.rank >= 6)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                anim.SetTrigger("BeegGun");
                yield return new WaitForSecondsRealtime(0.2f);
                Instantiate(beegBoltPrefab, transform.position, Quaternion.identity, transform);
                sm.StopAllCoroutines();
                sm.StartCoroutine(sm.ResetStyleRank(7));
                sm.rank = 0;
            }
        }
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

    IEnumerator Death()
    {
        anim.SetBool("Death", true);
        yield return new WaitForSecondsRealtime(2f);
        gameObject.SetActive(false);
    }
}
