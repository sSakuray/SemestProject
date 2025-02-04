using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] internal List<UnityEngine.UI.Slider> SliderToGroup;
    [SerializeField] internal AudioMixer audioMixer;

    void Start()
    {
        foreach (Slider pair in SliderToGroup) 
        {
            pair.onValueChanged.AddListener((float valu) =>
            {
                UpdateVolume(pair.gameObject.name, valu);
            }
            );
        }
    }
    private void UpdateVolume(string fltn,float setva)
    {
        if (audioMixer.GetFloat(fltn,out float value) == true)
        {
            audioMixer.SetFloat(fltn,setva);
        }
    }
}
