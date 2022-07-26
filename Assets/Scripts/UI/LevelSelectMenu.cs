using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectMenu : MonoBehaviour
{
    public int totalLevel = 0;

    int unlockedLevel = 1;

    public LevelButton[] levelButtons;

    private int totalPage = 0;

    private int page = 0;

    private int pageItem = 10;

    public GameObject nextButton,backButton;

    private void OnEnable()
    {
        levelButtons = GetComponentsInChildren<LevelButton>();
    }

    void Start()
    {
        Refresh();
    }

    public void StartLevel(int level)
    {
        if(level <= unlockedLevel)
        {
          //SceneManager.LoadScene("Level " + level.ToString());
          SceneManager.LoadScene(level);
        }
    }

    public void ClickNext()
    {
        page +=1;
        Refresh();
    }

    public void ClickBack()
    {
        page -= 1;
        Refresh();
    }

    public void Refresh()
    {
        unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        totalPage = (totalLevel / pageItem) - 1;

        int indax = page * pageItem;

        for (int i = 0; i < levelButtons.Length; i++)
        {
            int level = indax + i + 1;

            if(level <= totalLevel)
            {
                levelButtons[i].gameObject.SetActive(true);
                levelButtons[i].levelSelectorButtonSetup(level, level <= unlockedLevel);
            }
            else
            {
                levelButtons[i].gameObject.SetActive(false);
            }
        }

        CheckButton();
    }

    private void CheckButton()
    {
        backButton.SetActive(page > 0);
        nextButton.SetActive(page < totalPage);
    }

    public void ResetLevel()
    {
        PlayerPrefs.DeleteAll();
    }
}
