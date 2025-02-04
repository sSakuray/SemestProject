using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class _AchievementControler : MonoBehaviour
{
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private TMP_Text _descriptionText;
    [SerializeField] private Image _image;
    [SerializeField] private Achivment _currrenctAchievement;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    internal void PopUp(Achivment achivm)
    {
        if (achivm != null && gameObject.activeInHierarchy)
        {
           _currrenctAchievement = achivm;
            _titleText.text = _currrenctAchievement.Title;
            _descriptionText.text = _currrenctAchievement.Descrpt;
            _image.sprite = _currrenctAchievement.icon;
            _animator.SetTrigger("popup");
        }
    }
}
