using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    public int levelIndax = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        NextLevel();
    }

    public void NextLevel()
    {
        Debug.Log(levelIndax);
        SceneManager.LoadScene(levelIndax + 1);

        if (levelIndax >= PlayerPrefs.GetInt("UnlockedLevel"))
        {
            PlayerPrefs.SetInt("UnlockedLevel", levelIndax);
        }
       
    }
}
