using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    private void Awake()
    {
        FindObjectOfType<AudioManager>().Play("FinishMusic");
    }
    public void EndApplication()
    {
        Application.Quit();
    }
}