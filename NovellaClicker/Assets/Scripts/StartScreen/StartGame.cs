using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Button Start;
    [SerializeField] private GameObject StartScreen;
    [SerializeField] private GameObject MainScreen;

    private void Update()
    {
        Start.onClick.AddListener(StarterGame);
    }

    private void StarterGame()
    {
        StartScreen.SetActive(false);
        MainScreen.SetActive(true);

    }
}
