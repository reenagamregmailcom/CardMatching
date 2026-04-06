using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class GenerateBoard : MonoBehaviour
{
    [UnitHeaderInspectable("UI Canvas")]
   [SerializeField] private Transform Board;
   [SerializeField] private GameObject cardPrefab;
   [SerializeField] private RectTransform panelRow;
   [SerializeField] private Button loadMenuSceneButton;
   public Sprite[] icons;
   [SerializeField] private List<int> ids;
   [SerializeField] private List<Card> allCards;
    void Start()
    {
        Button btn = loadMenuSceneButton.GetComponent<Button>();
		btn.onClick.AddListener(LoadMenuSceneOnClick);

       ids = new List<int>();

        for (int i = 0; i < (SetLevel.HorizontalLayoutCount * SetLevel.VerticalLayoutCount) / 2; i++)
        {
            ids.Add(i);
            ids.Add(i);
        }
        Shuffle(ids);

        AutoGenerateBoard();
    }

    void AutoGenerateBoard()
    {
        RectTransform rowParent;
        for(int rowIndex = 0; rowIndex < SetLevel.HorizontalLayoutCount ; rowIndex++)
        {
            rowParent = Instantiate(panelRow, Board);
            for(int columnIndex = 0; columnIndex < SetLevel.VerticalLayoutCount ; columnIndex++)
            {
                GameObject freshcard = Instantiate(cardPrefab, rowParent);
                Card c = freshcard.GetComponent<Card>();
                int cardId = rowIndex * SetLevel.VerticalLayoutCount + columnIndex;
                c.id = ids[cardId];
                c.icon = icons[ids[cardId]];
                allCards.Add(c);
            }
        }
        StartCoroutine(ShowCaseCardsInitially());
    }

    void Shuffle(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rand = Random.Range(i, list.Count);
            int temp = list[i];
            list[i] = list[rand];
            list[rand] = temp;
        }
    }

   IEnumerator ShowCaseCardsInitially()
    {
        for (int i = 0; i < allCards.Count; i++)
        {
             allCards[i].Flip();
        }
       
        yield return new WaitForSeconds(3f);

        for (int i = 0; i < allCards.Count; i++)
        {
             allCards[i].Hide();
        }
    }
void LoadMenuSceneOnClick()
   {
		SceneManager.LoadScene(0);
    }
}
