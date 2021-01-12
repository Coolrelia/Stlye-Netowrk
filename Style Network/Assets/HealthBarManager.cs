using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarManager : MonoBehaviour
{
    public GameObject healthUnit10;
    public GameObject healthUnit20;
    public GameObject healthUnit30;
    public GameObject healthUnit40;
    public GameObject healthUnit50;
    public GameObject healthUnit60;
    public GameObject healthUnit70;
    public GameObject healthUnit80;
    public GameObject healthUnit90;
    public GameObject healthUnit100;

    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }


    private void Update()
    {
        if(player.health < 100 && player.health > 89)
        {
            healthUnit100.SetActive(false);
        }
        if (player.health < 90 && player.health > 79)
        {
            healthUnit90.SetActive(false);
        }
        if (player.health < 80 && player.health > 69)
        {
            healthUnit80.SetActive(false);
        }
        if (player.health < 70 && player.health > 59)
        {
            healthUnit70.SetActive(false);
        }
        if (player.health < 60 && player.health > 49)
        {
            healthUnit60.SetActive(false);
        }
        if (player.health < 50 && player.health > 39)
        {
            healthUnit50.SetActive(false);
        }
        if (player.health < 40 && player.health > 29)
        {
            healthUnit40.SetActive(false);
        }
        if (player.health < 30 && player.health > 19)
        {
            healthUnit30.SetActive(false);
        }
        if (player.health < 20 && player.health > 9)
        {
            healthUnit20.SetActive(false);
        }
        if (player.health < 10 && player.health >= 0)
        {
            healthUnit10.SetActive(false);
        }
    }
}
