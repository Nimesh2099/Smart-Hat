using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OpenSupport()
    {
        Application.OpenURL("https://ko-fi.com/nim0games");
    }

    public void OnMute(bool isMuted)
    {
        if(isMuted)
        {
            audioMixer.SetFloat("Volume", -80f);
        }
        else
        {
            audioMixer.SetFloat("Volume", 0f);
        }

    }
        
}
