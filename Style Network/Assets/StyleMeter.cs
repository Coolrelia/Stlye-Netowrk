using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StyleMeter : MonoBehaviour
{
    public Sprite F;
    public Sprite E;
    public Sprite D;
    public Sprite C;
    public Sprite B;
    public Sprite A;
    public Sprite S;

    public Sprite background;
    public Sprite backgroundS;

    public SpriteRenderer currentLetter;
    public SpriteRenderer currentBackground;

    public GameObject qIcon;
    public GameObject wIcon;
    public GameObject eIcon;

    public int rank;

    private void Start()
    {
        StartCoroutine(ResetStyleRank(7));
    }

    private void Update()
    {
        StyleMeterRank();
        AbilityIcons();
    }

    public IEnumerator ResetStyleRank(float time)
    {
        while(true)
        {
            yield return new WaitForSecondsRealtime(time);
            rank = 0;
        }
    }

    private void AbilityIcons()
    {
        if (rank < 1)
        {
            qIcon.GetComponent<SpriteRenderer>().color = Color.grey;
        }
        else
        {
            qIcon.GetComponent<SpriteRenderer>().color = Color.white;
        }

        if (rank < 3)
        {
            wIcon.GetComponent<SpriteRenderer>().color = Color.grey;
        }
        else
        {
            wIcon.GetComponent<SpriteRenderer>().color = Color.white;
        }

        if(rank < 5)
        {
            eIcon.GetComponent<SpriteRenderer>().color = Color.grey;
        }
        else
        {
            eIcon.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    private void StyleMeterRank()
    {
        switch(rank)
        {
            case 0:
                currentLetter.sprite = F;
                currentBackground.sprite = background;
                break;

            case 1:
                currentLetter.sprite = E;
                currentBackground.sprite = background;
                break;

            case 2:
                currentLetter.sprite = D;
                currentBackground.sprite = background;
                break;

            case 3:
                currentLetter.sprite = C;
                currentBackground.sprite = background;
                break;

            case 4:
                currentLetter.sprite = B;
                currentBackground.sprite = background;
                break;

            case 5:
                currentLetter.sprite = A;
                currentBackground.sprite = background;
                break;

            case 6:
                currentLetter.sprite = S;
                currentBackground.sprite = backgroundS;
                break;
        }
    }


}
