using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreloadScript : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        SceneManager.LoadScene(1);
    }
}
