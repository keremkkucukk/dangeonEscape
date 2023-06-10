using UnityEngine;
using UnityEngine.UI;

public class MaınMenu_UI : MonoBehaviour
{
    public void SwitchMenuTo(GameObject uiMenu)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        uiMenu.SetActive(true);
    }

    public void SetGameDifficulty(int i) => GameManager.instance.difficulty = i;
}
