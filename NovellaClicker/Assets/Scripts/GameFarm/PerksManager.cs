using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerksManager : MonoBehaviour
{
    [Header("Цена")]
    [SerializeField] Button buyAutoClicker;
    [SerializeField] int priceAutoClicker;
    [SerializeField] Text priceAutoClickerText;

    [Header("Насколько больше будет увеличиваться доход и стоимость прокачки")]
    [SerializeField] float xBoostMoney;
    [SerializeField] float xBuyAutoClicker;



    [Header("Цена")]
    [SerializeField] Button buyClickerUpgrade;
    [SerializeField] int priceClickerUpgrade;
    [SerializeField] Text priceClickerUpgradeText;

    [Header("Насколько больше будет увеличиваться доход и стоимость прокачки")]
    [SerializeField] float xBoostMoneyPerClick;
    [SerializeField] float xBuyClickerUpgrade;


    [Header("Цена")]
    [SerializeField] Button buyDamage;
    [SerializeField] int priceDamage;
    [SerializeField] Text priceDamageText;
    [Header("Насколько больше будет увеличиваться урон и стоимость прокачки")]
    [SerializeField] float xBoostDamage;
    [SerializeField] float xBuyDamage;


    [Header("Цена")]
    [SerializeField] Button buyHealth;
    [SerializeField] int priceHealth;
    [SerializeField] Text priceHealthText;
    [Header("Насколько больше будет увеличиваться хп и стоимость прокачки")]
    [SerializeField] float xBoostHealth;
    [SerializeField] float xBuyHealth;



    [Header("Цена")]
    [SerializeField] Button buyRegeneration;
    [SerializeField] int priceRegeneration;
    [SerializeField] Text priceRegenerationText;

    [Header("Насколько больше будет увеличиваться реген и стоимость прокачки")]
    [SerializeField] float xBoostRegeneration;
    [SerializeField] float xBuyRegeneration;


    PlayerManager playerManager;

    [HideInInspector] public AutoClicker autoClicker;
    [HideInInspector] public Regeneration regeneration;

    int num;
    void Start()
    {
        buyAutoClicker.onClick.AddListener(BuyAutoClicker);
        buyClickerUpgrade.onClick.AddListener(BuyClickerUpgrade);
        buyDamage.onClick.AddListener(BuyDamage);
        buyHealth.onClick.AddListener(BuyHealth);
        buyRegeneration.onClick.AddListener(BuyRegeneration);
        playerManager = FindObjectOfType<PlayerManager>();
        autoClicker = FindObjectOfType<AutoClicker>();
        regeneration = FindObjectOfType<Regeneration>();
        priceAutoClickerText.text = $"-{priceAutoClicker}$ \n +{(autoClicker.countMoney * xBoostMoneyPerClick) - autoClicker.countMoney} $/sec";
        priceClickerUpgradeText.text = $"-{priceClickerUpgrade}$ \n +{(playerManager.coinByClick * xBoostMoneyPerClick) - playerManager.coinByClick} $/click";
        priceRegenerationText.text = $"-{priceRegeneration}$ \n +{(regeneration.countHealth * xBoostRegeneration) - regeneration.countHealth }hp /{regeneration.seconds}sec";
        priceHealthText.text = $"-{priceHealth}$ \n +{(playerManager.MaxHealth * xBoostHealth) - playerManager.MaxHealth} max Hp";
        priceDamageText.text = $"-{priceDamage}$ \n +{(playerManager.damage * xBoostDamage) - playerManager.damage}";
    }

    void BuyAutoClicker()
    {
        if(autoClicker.enabled == false && priceAutoClicker <= playerManager.coins)
        {
            playerManager.AddMoney(-priceAutoClicker);
            priceAutoClicker = Mathf.RoundToInt(priceAutoClicker * xBuyAutoClicker);
            priceAutoClickerText.text = $"-{priceAutoClicker}$ \n +{(autoClicker.countMoney * xBoostMoneyPerClick) - autoClicker.countMoney} $/sec";
            autoClicker.enabled = true;
            playerManager.Stats();
        }
        else if(autoClicker.enabled == true && priceAutoClicker <= playerManager.coins)
        {
            playerManager.AddMoney(-priceAutoClicker);
            priceAutoClicker = Mathf.RoundToInt(priceAutoClicker * xBuyAutoClicker);
            autoClicker.countMoney = Mathf.RoundToInt(autoClicker.countMoney * xBoostMoneyPerClick);
            priceAutoClickerText.text = $"-{priceAutoClicker}$ \n +{(autoClicker.countMoney * xBoostMoneyPerClick) - autoClicker.countMoney} $/{autoClicker.timePerClick} sec";
            playerManager.Stats();
        }
    }

    void BuyClickerUpgrade()
    {
        if(priceClickerUpgrade <= playerManager.coins)
        {
            playerManager.AddMoney(-priceClickerUpgrade);
            priceClickerUpgrade = Mathf.RoundToInt(priceClickerUpgrade * xBuyClickerUpgrade);
            playerManager.coinByClick = Mathf.RoundToInt(playerManager.coinByClick * xBoostMoneyPerClick);
            priceClickerUpgradeText.text = $"-{priceClickerUpgrade}$ \n +{(playerManager.coinByClick * xBoostMoneyPerClick) - playerManager.coinByClick} $/click";
        }
    }

    void BuyRegeneration()
    {
        if(regeneration.enabled == false && priceRegeneration <= playerManager.coins)
        {
            playerManager.AddMoney(-priceRegeneration);
            priceRegeneration = Mathf.RoundToInt(priceRegeneration * xBuyRegeneration);
            priceRegenerationText.text = $"-{priceRegeneration}$ \n +{(regeneration.countHealth * xBoostRegeneration) - regeneration.countHealth }hp /{regeneration.seconds} sec";
            regeneration.enabled = true;
            playerManager.Stats();
        }

        else if(regeneration.enabled == true && priceRegeneration <= playerManager.coins)
        {
            playerManager.AddMoney(-priceRegeneration);
            priceRegeneration = Mathf.RoundToInt(priceRegeneration * xBuyRegeneration);
            regeneration.countHealth = Mathf.RoundToInt(regeneration.countHealth * xBoostRegeneration);
            priceRegenerationText.text = $"-{priceRegeneration}$ \n +{(regeneration.countHealth * xBoostRegeneration) - regeneration.countHealth }hp /{regeneration.seconds} sec";
            playerManager.Stats();
        }
    }

    void BuyHealth()
    {
        if(priceHealth <= playerManager.coins)
        {
            playerManager.AddMoney(-priceHealth);
            priceHealth = Mathf.RoundToInt(priceHealth * xBuyHealth);
            num = Mathf.RoundToInt(playerManager.MaxHealth * xBoostHealth);
            playerManager.MaxHealth = num;
            playerManager.health = num;
            priceHealthText.text = $"-{priceHealth}$ \n +{(playerManager.MaxHealth * xBoostHealth) - playerManager.MaxHealth} max Hp";
            playerManager.Stats();
        }
    }

    void BuyDamage()
    {
        if(priceDamage <= playerManager.coins)
        {
            playerManager.AddMoney(-priceDamage);
            playerManager.AddDamage(playerManager.damage = Mathf.RoundToInt((playerManager.damage * xBoostDamage) - playerManager.damage));
            priceDamage = Mathf.RoundToInt(priceDamage * xBuyDamage);
            priceDamageText.text = $"-{priceDamage}$ \n +{(playerManager.damage * xBoostDamage) - playerManager.damage}";
        }
    }
}
