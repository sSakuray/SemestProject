using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] Button clickerButton;
    public int coinByClick;

    [Header("Вывод количества монет")]
    public Text CoinsText;
    public int coins;

    [Header("Вывод количества здоровья")]
    public Text HealthText;
    public Text HealthText2;
    public int health;
    [SerializeField] Image HpBar;
    [SerializeField] Image HpBar2;
    [HideInInspector] public int MaxHealth;

    [Header("Вывод количества урона")]
    public Text DamageText;
    public int damage;

    [Header("Вывод статистики характеристик")]
    public Text CoinsStatsText;
    public Text HealthStatsText;

    PerksManager perksManager;
    [SerializeField] AutoClicker autoClicker;
    [SerializeField] Regeneration regeneration;
    [SerializeField] KristallParticles kristallParticles;

    [Header("Сет-ап ачивок за клики")]
    [SerializeField] internal AchievementManager Ach_Manager;
    [SerializeField] private int _clickAmmount = 0;

    private Dictionary<Achivment, AchivmentsEnum> _avalAchivments;
    void Start()
    {
        _avalAchivments = Ach_Manager.GetAchivmensListByType("coins");
        _avalAchivments.AddRange(Ach_Manager.GetAchivmensListByType("click"));
        MaxHealth = health;
        perksManager = FindObjectOfType<PerksManager>();
        //kristallParticles = FindObjectOfType<KristallParticles>();

        clickerButton.onClick.AddListener(() => {
            _clickAmmount++;
            AddMoney(coinByClick);
        }
        );
        Stats();
    }

    private void Update()
    {
        HealthText.text = health.ToString() + "/" + MaxHealth.ToString();
        HealthText2.text = health.ToString() + "/" + MaxHealth.ToString();
    }

    public void AddMoney(int count)
    {
        coins += count;
        CoinsText.text = coins.ToString();
        kristallParticles.Particles();
        CheckAchivments();
    }
    internal void CheckAchivments()
    {
        foreach (KeyValuePair<Achivment,AchivmentsEnum> keypair in _avalAchivments)
        {
            if (keypair.Key.Type.ToLower() == "click")
            {
                int requiredammount = keypair.Key.ammount;
                if (requiredammount <= _clickAmmount)
                {
                    Ach_Manager.Unlock(keypair.Value);
                }
            }
            else if (keypair.Key.Type.ToLower() == "coins")
            {
                int requiredammount = keypair.Key.ammount;
                if (coins >= requiredammount)
                {
                    Ach_Manager.Unlock(keypair.Value);
                }
            }
        }
    }
    public void AddHealth(int count)
    {
        health += count;
        if(health >= MaxHealth)
        {
            health = MaxHealth;
        }
        HealthText.text = health.ToString() + "/" + MaxHealth.ToString();
        HealthText2.text = health.ToString() + "/" + MaxHealth.ToString();
        float a = health;
        float b = MaxHealth;
        HpBar.fillAmount = a / b;
        HpBar2.fillAmount = a / b;
    }

    public void AddDamage(int count)
    {
        damage += count;
        DamageText.text = damage.ToString();
    }
    float tom = 0.5f;
    private void FixedUpdate()
    {
        tom -= Time.deltaTime;
        if (tom <= 0)
        {
            Stats();
            tom = 0.5f;
        }
    }

    public void Stats()
    {
        HealthText.text = health.ToString() + "/" + MaxHealth.ToString();
        HealthText2.text = health.ToString() + "/" + MaxHealth.ToString();
        CoinsText.text = coins.ToString();
        DamageText.text = damage.ToString();
        if(autoClicker.enabled == true)
        {
            CoinsStatsText.text = $"+{autoClicker.countMoney} $/{autoClicker.timePerClick} sec";
        }
        if(regeneration.enabled == true)
        {
            HealthStatsText.text = $"+{regeneration.countHealth} hp/{regeneration.seconds} sec";
        }
    }
}
