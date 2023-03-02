using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Setvol : MonoBehaviour
{
    [SerializeField] private AudioMixer audiom;
    [SerializeField] private string nameParam;
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();

    }

    public void SetVolume(float vol)
    {
        audiom.SetFloat(nameParam, Mathf.Log10(vol) * 30);
        PlayerPrefs.SetFloat(nameParam, vol);
    }

  
}
