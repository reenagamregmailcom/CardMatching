using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GenerateBoard : MonoBehaviour
{
    [UnitHeaderInspectable("UI Canvas")]
   [SerializeField] private Transform Board;
   [SerializeField] private GameObject cardPrefab;
   [SerializeField] private RectTransform panelRow;
   [SerializeField] private Button loadMenuSceneButton;
   public Sprite[] icons;
   List<int> ids;
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
            }
        }
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

void LoadMenuSceneOnClick()
   {
		SceneManager.LoadScene(0);
    }
}
