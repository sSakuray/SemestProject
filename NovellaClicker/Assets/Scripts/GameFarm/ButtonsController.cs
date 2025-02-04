using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour
{
    [Header("Окно перков")]
    [SerializeField] Button PerksOpen;
    [SerializeField] Button PerksClose;
    [SerializeField] GameObject PerksWin;


    [Header("Окно ачивок")]
    [SerializeField] Button AchivOpen;
    [SerializeField] Button AchivClose;
    [SerializeField] GameObject AchivWin;


    [Header("Окно настроек")]
    [SerializeField] Button SettingsOpen;
    [SerializeField] Button SettingsClose;
    [SerializeField] GameObject SettingsWin;


    [Header("Переход на экран к боссу и к фарму")]
    [SerializeField] Button bossFight;
    [SerializeField] Button farm;
    [SerializeField] GameObject farmMenu;
    [SerializeField] GameObject bossMenu;


    void Start()
    {
        PerksOpen.onClick.AddListener(() => PerksWinCon(true));
        PerksClose.onClick.AddListener(() => PerksWinCon(false));

        AchivOpen.onClick.AddListener(() => AchivWinCon(true));
        AchivClose.onClick.AddListener(() => AchivWinCon(false));

        SettingsOpen.onClick.AddListener(() => SettingsWinCon(true));
        SettingsClose.onClick.AddListener(() => SettingsWinCon(false));

        bossFight.onClick.AddListener(BossFight);
        farm.onClick.AddListener(Farm);
    }

    void PerksWinCon(bool TuF)
    {
        PerksWin.SetActive(!PerksWin.activeInHierarchy);
        SettingsWin.SetActive(false);
        AchivWin.SetActive(false);
    }

    void AchivWinCon(bool TuF)
    {
        AchivWin.SetActive(!AchivWin.activeInHierarchy);
        SettingsWin.SetActive(false);
        PerksWin.SetActive(false);
    }

    void SettingsWinCon(bool TuF)
    {
        SettingsWin.SetActive(!SettingsWin.activeInHierarchy);
        AchivWin.SetActive(false);
        PerksWin.SetActive(false);
    }

    void BossFight()
    {
        farmMenu.SetActive(false);
        bossMenu.SetActive(true);
    }

    void Farm()
    {
        farmMenu.SetActive(true);
        bossMenu.SetActive(false);
    }
}
