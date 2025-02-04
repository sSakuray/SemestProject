using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossManage : MonoBehaviour
{
    [SerializeField] Button clickOnBoss1;
    [SerializeField] Button clickOnBoss2;
    [SerializeField] Button clickOnBoss3;
    [SerializeField] GameObject Boss1;
    [SerializeField] GameObject Boss2;
    [SerializeField] GameObject Boss3;
    [SerializeField] AudioSource deathsource;


    [Header("Вывод количества здоровья босса")]
    [SerializeField] public float maxHealthBoss1;
    [SerializeField] public float maxHealthBoss2;
    [SerializeField] public float maxHealthBoss3;
    public float healthBoss1;
    public float healthBoss2;
    public float healthBoss3;
    [SerializeField] Image HpBarBoss1;
    [SerializeField] Image HpBarBoss2;
    [SerializeField] Image HpBarBoss3;

    [SerializeField] internal AchievementManager Ach_Manager;
    PlayerManager playerManager;
    private Dictionary<Achivment, AchivmentsEnum> _avalAchivments;

    void Start()
    {
        _avalAchivments = Ach_Manager.GetAchivmensListByType("boss");
        playerManager = FindObjectOfType<PlayerManager>();
        maxHealthBoss1 = healthBoss1;
        maxHealthBoss2 = healthBoss2;
        maxHealthBoss3 = healthBoss3;
        clickOnBoss1.onClick.AddListener(TakeDamage1);
        clickOnBoss2.onClick.AddListener(TakeDamage2);
        clickOnBoss3.onClick.AddListener(TakeDamage3);
    }

    public void TakeDamage1()
    {
        healthBoss1 -= playerManager.damage;
        HpBarBoss1.fillAmount = healthBoss1 / maxHealthBoss1;
        if (healthBoss1 <= 0)
        {
            deathsource.Play();
            Boss1.SetActive(false);
            CheckAchivments();
            Boss2.SetActive(true);
        }
    }

    public void TakeDamage2()
    {
        healthBoss2 -= playerManager.damage;
        HpBarBoss2.fillAmount = healthBoss2 / maxHealthBoss2;
        if (healthBoss2 <= 0)
        {
            deathsource.Play();
            Boss2.SetActive(false);
            CheckAchivments();
            Boss3.SetActive(true);
        }
    }

    public void TakeDamage3()
    {
        healthBoss3 -= playerManager.damage;
        HpBarBoss3.fillAmount = healthBoss3 / maxHealthBoss3;
        if (healthBoss3 <= 0)
        {
            deathsource.Play();
            CheckAchivments();
            Boss3.SetActive(false);
        }
    }
    internal void CheckAchivments()
    {
        foreach (KeyValuePair<Achivment, AchivmentsEnum> keypair in _avalAchivments)
        {
            int requiredammount = keypair.Key.ammount;
            if (requiredammount == 1 && healthBoss1<=0)
            {
                Ach_Manager.Unlock(keypair.Value);
            }
            else
            if (requiredammount == 2 && healthBoss2 <= 0)
            {
                Ach_Manager.Unlock(keypair.Value);
            }
            else
            if (requiredammount == 3 && healthBoss3 <= 0)
            {
                Ach_Manager.Unlock(keypair.Value);
            }
        }
    }
}

