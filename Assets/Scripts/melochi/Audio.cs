using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class Audio : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] AudioSource audiosrc;
    public static float mvolume = 0.5f;

    private void Start()
    {
        audiosrc.volume = mvolume;
        slider.value = mvolume;
    }
    public void changevol()
    {
        mvolume = slider.value;
        audiosrc.volume = mvolume;
        slider.value = mvolume;
        Memory.mVolue = mvolume;
    }
}
