using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class AchievementManager : MonoBehaviour
{
    [SerializeField] private _AchievementControler _achievementControler;
    [SerializeField] private _AchievementControler _achievementControler2;
    [SerializeField] private AchivmentsDataSO _achivmentsDataSO;
    [SerializeField] private GameObject _AchievementListItemPrefab;
    [SerializeField] private Transform _AchievementList;

    internal void Unlock(AchivmentsEnum achivment)
    {
        Achivment achievment = _achivmentsDataSO.Achivments[(int)achivment-1];
        if (achievment != null && !achievment.AUnlocked)
        {
            achievment.AUnlocked = true;
            Show(achievment);
            LoadAchievements();
        }
    }
    internal void Show(Achivment achievement)
    {
        if (achievement == null)
        {
            Debug.LogWarning("No achievement found by id: " + achievement.ToString());
            return;
        }
        _achievementControler.PopUp(achievement);
        _achievementControler2.PopUp(achievement);
    }
    internal void Show(AchivmentsEnum achievement)
    {
        Achivment achievment = _achivmentsDataSO.Achivments[(int)achievement-1];
        if (achievment == null)
        {
            Debug.LogWarning("No achievement found by id: " + achievement.ToString());
            return;
        }
        _achievementControler.PopUp(achievment);
        _achievementControler2.PopUp(achievment);
    }
    internal Dictionary<Achivment,AchivmentsEnum> GetAchivmensListByType(string type)
    {
        Dictionary<Achivment, AchivmentsEnum> output = new();

        foreach (Achivment achivment in _achivmentsDataSO.Achivments)
        {
            if (achivment.Type.ToLower().Equals(type.ToLower()))
            {
                string modifiedid = achivment.ID;
                modifiedid = modifiedid.Contains(' ')?modifiedid.Replace(' ', '_') : achivment.ID;
                if (System.Enum.TryParse< AchivmentsEnum>(modifiedid,out AchivmentsEnum result) == true && result != AchivmentsEnum.none)
                {
                    output.Add(achivment, result);
                } else
                {
                    output.Add(achivment, AchivmentsEnum.none);
                }
            }
        }

        return output;
    }
    private void Start()
    {
        foreach(Achivment achievementa in _achivmentsDataSO.Achivments)
        {
            achievementa.AUnlocked = false;
        }
        LoadAchievements();
        
    }
    private void LoadAchievements()
    {
        if (_achivmentsDataSO != null)
        {
            foreach(Transform child in _AchievementList)
            {
                Destroy(child.gameObject);
            }
            foreach (Achivment achvm in _achivmentsDataSO.Achivments)
            {
                GameObject GO = Instantiate(_AchievementListItemPrefab, _AchievementList);

                if (achvm == null)
                {
                    Destroy(GO);
                }
                else
                {
                    if (GO.TryGetComponent<AchvmntListItem>(out AchvmntListItem achvmnt))
                    {
                        achvmnt.SetUp(achvm);
                    } else
                    {
                        Destroy(GO);
                    }
                }
            }
        }
    }
}
