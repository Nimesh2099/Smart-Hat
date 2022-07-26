using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isLooked = true;

    void Update()
    {
        if(!isLooked)
        {
            this.gameObject.SetActive(false);
        }
    }
}
