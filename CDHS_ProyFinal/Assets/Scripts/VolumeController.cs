using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private Volume volumeObject;

    public void ChangeSmoothness(int camera)
    {
        if (volumeObject.profile.TryGet<Vignette>(out Vignette vignetteVolume))
        {
            if (camera == 1)
                vignetteVolume.smoothness.value = 0.5f;
            else
                vignetteVolume.smoothness.value = 0.01f;
        }
    }
}
