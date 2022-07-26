using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelButton : MonoBehaviour
{

    public LevelSelectMenu menu;

    public Sprite lockSprite,unlockedSprite;

    public TextMeshProUGUI levelText;

    private int level = 0;

    private Button button;

    private Image image;

    private void OnEnable()
    {
        button = GetComponent<Button>();

        image = GetComponent<Image>();

    }

    public void levelSelectorButtonSetup(int level,bool isUnlocked)
    {
        this.level = level;
        levelText.text = level.ToString();

        if(isUnlocked)
        {
            image.sprite = unlockedSprite;
            button.enabled = true;
            gameObject.SetActive(true);
        }
        else
        {
            image.sprite = lockSprite;
            button.enabled = false;
            levelText.gameObject.SetActive(false);
            //gameObject.SetActive(false);
        }
    }

    public void OnClick()
    {
        menu.StartLevel(level);
    }
}
