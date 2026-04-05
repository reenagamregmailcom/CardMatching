using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SetLevel : MonoBehaviour
{
    int levelIndex;
    int[][] levelLayoutArray;
    int[] selectedLevel;
    //[SerializeField] private Toggle[] Leveltoggles;
    [SerializeField] private Button loadSceneButton;
    public static int HorizontalLayoutCount = 4, VerticalLayoutCount = 2;
    void Start()
    {
        Button btn = loadSceneButton.GetComponent<Button>();
		btn.onClick.AddListener(LoadSceneOnClick);

       levelLayoutArray = new int[][] 
{
    new int[] {2, 4},
    new int[] {3, 4},
    new int[] {4, 4}
};

levelIndex = 0;//default
selectedLevel = levelLayoutArray[levelIndex];//default

    }

   public void SetDifficultyOfLevl(int _levelIndex)
    {
//if(Leveltoggles[_levelIndex].isOn)
//{       
       levelIndex = _levelIndex;
       selectedLevel = levelLayoutArray[levelIndex];
//}
//print(levelLayoutArray[levelIndex][1]);
    }

   void LoadSceneOnClick()
   {
    HorizontalLayoutCount = levelLayoutArray[levelIndex][0];
    VerticalLayoutCount = levelLayoutArray[levelIndex][1];
		SceneManager.LoadScene(1);
    }
}
