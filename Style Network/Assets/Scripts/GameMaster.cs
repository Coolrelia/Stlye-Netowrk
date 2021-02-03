using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public GameObject sucklet;
    public GameObject player;

    public GameObject winText;
    public GameObject loseText;

    public GameObject saturdayNight;
    public GameObject noDate;
    public GameObject shasta;
    public GameObject allRushMixtape;
    public GameObject letsStyle;

    public bool intro;

    public void Start()
    {
        Time.timeScale = 0;
        StartCoroutine(Intro());
    }

    public void Update()
    {
        StartCoroutine(Win(2f));
        StartCoroutine(Lose(2f));
    }

    IEnumerator Intro()
    {
        intro = true;
        Time.timeScale = 0;
        saturdayNight.SetActive(true);
        yield return new WaitForSecondsRealtime(1.5f);
        saturdayNight.SetActive(false);
        noDate.SetActive(true);
        yield return new WaitForSecondsRealtime(1.5f);
        noDate.SetActive(false);
        shasta.SetActive(true);
        yield return new WaitForSecondsRealtime(1.7f);
        shasta.SetActive(false);
        allRushMixtape.SetActive(true);
        yield return new WaitForSecondsRealtime(1.9f);
        allRushMixtape.SetActive(false);
        letsStyle.SetActive(true);
        yield return new WaitForSecondsRealtime(1.5f);
        letsStyle.SetActive(false);
        Time.timeScale = 1;
        intro = false;
    }


    IEnumerator Win(float time)
    {
        if(sucklet.activeSelf == false)
        {
            yield return new WaitForSecondsRealtime(time);
            winText.SetActive(true);
            yield return new WaitForSecondsRealtime(2f);
            winText.SetActive(false);
            SceneManager.LoadScene("StartScreen");
        }
    }

    IEnumerator Lose(float time)
    {
        if(player.activeSelf == false)
        {
            yield return new WaitForSecondsRealtime(time);
            loseText.SetActive(true);
            yield return new WaitForSecondsRealtime(2f);
            loseText.SetActive(false);
            SceneManager.LoadScene("StartScreen");
        }
    }
}
