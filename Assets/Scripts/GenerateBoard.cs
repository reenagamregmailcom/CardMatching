using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GenerateBoard : MonoBehaviour
{
    [UnitHeaderInspectable("UI Canvas")]
   [SerializeField] private Transform Board;
   [SerializeField] private GameObject card;
   [SerializeField] private RectTransform panelRow;
   [SerializeField] private Button loadMenuSceneButton;
    void Start()
    {
         Button btn = loadMenuSceneButton.GetComponent<Button>();
		btn.onClick.AddListener(LoadMenuSceneOnClick);
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
                Instantiate(card, rowParent);
            }

        }
    }

void LoadMenuSceneOnClick()
   {
		SceneManager.LoadScene(0);
    }
}
