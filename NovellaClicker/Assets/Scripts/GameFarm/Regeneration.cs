using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regeneration : MonoBehaviour
{
    [Header("Сколько хп хилит")]
    public int countHealth;
    [Header("Как быстро?(в секундах)")]
    public float seconds;
    PlayerManager playerManager;
    bool isHealing;
    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }

    void Update()
    {
        if(playerManager.health < playerManager.MaxHealth && !isHealing)
        {
            StartCoroutine(GetHealth());
        }
        else if(playerManager.health >= playerManager.MaxHealth)
        {
            playerManager.health = playerManager.MaxHealth;
        }
    }
    IEnumerator GetHealth()
    {
        isHealing = true;
        yield return new WaitForSeconds(seconds);
        playerManager.AddHealth(countHealth);
        isHealing = false;
    }
}
