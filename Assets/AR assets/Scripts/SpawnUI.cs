using UnityEngine;

public class SpawnUI : MonoBehaviour
{
    public GameObject uiGameMenu;

    void Awake()
    {
        Instantiate(uiGameMenu);
    }
}