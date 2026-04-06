using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Card firstCard;
    public Card secondCard;

    public bool canFlip = true;
    [SerializeField] private int matchesCount, turnsCount;
    [SerializeField] private Text matchesText, turnsText;
    [SerializeField] private int totalPairs;

    void Start()
    {
        totalPairs = (SetLevel.HorizontalLayoutCount * SetLevel.VerticalLayoutCount) / 2;
    }

    public void CardFlipped(Card card)
    {
        if (firstCard == null)
        {
            firstCard = card;
        }
        else
        {
            secondCard = card;
            StartCoroutine(CheckMatch());
        }
    }

    IEnumerator CheckMatch()
    {
        canFlip = false;

        yield return new WaitForSeconds(1f);

        if (firstCard.id == secondCard.id)
        {
            firstCard = null;
            secondCard = null;
            matchesCount++;
            matchesText.text = matchesCount.ToString();
        }
        else
        {
            firstCard.Hide();
            secondCard.Hide();

            firstCard = null;
            secondCard = null;
        }
        turnsCount++;
        turnsText.text = turnsCount.ToString();
        canFlip = true;
        if(matchesCount == totalPairs)
        {
            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver()
    {
         yield return new WaitForSeconds(1f);
         //Debug.Log("Matched game over");
         SceneManager.LoadScene(0);
    }
}