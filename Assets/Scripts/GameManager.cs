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
    [SerializeField] private GameObject restartMenu;


    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // Enforce the singleton: if an instance already exists, destroy this one
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        
        // Optional: Keep this object alive across scene loads
        //DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        restartMenu.SetActive(false);
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
         restartMenu.SetActive(true);
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(1);
    }

    void OnDestroy()
    {
        Instance = null;
    }
}