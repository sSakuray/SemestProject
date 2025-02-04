using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AchvmntListItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private TMP_Text _descriptionText;
    [SerializeField] private UnityEngine.UI.Image _image;
    [SerializeField] private UnityEngine.UI.Image _colorimage;
    [SerializeField] private Achivment _currrenctAchievement;
    [SerializeField] internal bool _locked = false;
    [SerializeField] private Color _unlockcolor;
    [SerializeField] private Color _lockcolor;
    private void Change()
    {
        if (_currrenctAchievement != null)
        {
            _titleText.text = _currrenctAchievement.Title;
            _descriptionText.text = _currrenctAchievement.Descrpt;
            _image.sprite = _currrenctAchievement.icon;
            _locked = !_currrenctAchievement.AUnlocked;
        }
        if (_locked)
        {
            _colorimage.color = _lockcolor;
        }
        else
        {
            _colorimage.color = _unlockcolor;
        }
    }
    private void OnValidate()
    {
        Change();
    }

    private void Update()
    {
       Change();
    }
    public void SetUp(Achivment achivment)
    {
        if (achivment != null) {
            _currrenctAchievement = achivment;
            Change();
        }
    }
}
