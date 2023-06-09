using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject levelButton;
    [SerializeField] private Transform levelButtonParent;

    [SerializeField] private bool[] levelOpen;

    private void Start()
    {
        PlayerPrefs.SetInt("Level" + 1 + "Unlocked", 1);

        AssignLevelBooleans();


        for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
        {

            if (!levelOpen[i])
                return;

            string sceneName = "Level " + i;


            GameObject newButton = Instantiate(levelButton, levelButtonParent);
            newButton.AddComponent<Button>().onClick.AddListener(() => LoadLevel(sceneName));
            newButton.GetComponentInChildren<TextMeshProUGUI>().text = sceneName;
        }
    }

    private void AssignLevelBooleans()
    {
        for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            bool unlocked = PlayerPrefs.GetInt("Level" + i + "Unlocked") == 1;

            if (unlocked)
                levelOpen[i] = true;
            else
                return;
        }
    }

    public void LoadLevel(string sceneName)
    {
        GameManager.instance.SaveGameDifficulty();
        SceneManager.LoadScene(sceneName);
    }

    public void LoadNewGame()
    {
        for (int i = 2; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            bool unlocked = PlayerPrefs.GetInt("Level" + i + "Unlocked") == 1;

            if (unlocked)
                PlayerPrefs.SetInt("Level" + i + "Unlocked", 0);
            else
                SceneManager.LoadScene("level 1");
                return;
        }
    }

    public void LoadContinueGame()
    {
        for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            bool unlocked = PlayerPrefs.GetInt("Level" + i + "Unlocked") == 1;

            if(!unlocked)
            {
                SceneManager.LoadScene("Level " + (i - 1));
                return;
            }

        }
    }


}