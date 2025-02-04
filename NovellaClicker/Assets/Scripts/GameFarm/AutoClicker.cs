using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoClicker : MonoBehaviour
{
    [Header("Сколько денег за клик")]
    public int countMoney;

    [Header("Время перезарядки")]
    public float timePerClick;
    PlayerManager playerManager;
    
    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        StartCoroutine(GetMoney());
    }

    IEnumerator GetMoney()
    {
        while(true)
        {
            yield return new WaitForSeconds(timePerClick);
            playerManager.AddMoney(countMoney);
        }
    }
}
