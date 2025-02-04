using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float pitchdifference = 0.1f;
    [SerializeField] private Button button;
    private float currentpitch;
    void Start()
    {
        currentpitch = _audioSource.pitch;
        button.onClick.AddListener(OnPress);
    }

    void OnPress()
    {
        if (_audioSource != null)
        {
            float difpitch = UnityEngine.Random.Range(-pitchdifference/2, pitchdifference/2);
            _audioSource.pitch = currentpitch+difpitch;
            _audioSource.Play();
        }
    }
}
