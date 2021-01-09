using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StyleMeter : MonoBehaviour
{
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

    public int rank;

    private void Start()
    {
        InvokeRepeating("ResetStyleRank", 5f, 5f);
    }

    private void Update()
    {
        StyleMeterRank();
    }

    void ResetStyleRank()
    {
        rank--;
    }

    private void StyleMeterRank()
    {
        switch(rank)
        {
            case 0:
                currentLetter.sprite = E;
                currentBackground.sprite = background;
                break;

            case 1:
                currentLetter.sprite = D;
                currentBackground.sprite = background;
                break;

            case 2:
                currentLetter.sprite = C;
                currentBackground.sprite = background;
                break;

            case 3:
                currentLetter.sprite = B;
                currentBackground.sprite = background;
                break;

            case 4:
                currentLetter.sprite = A;
                currentBackground.sprite = background;
                break;

            case 5:
                currentLetter.sprite = S;
                currentBackground.sprite = backgroundS;
                break;
        }
    }


}
