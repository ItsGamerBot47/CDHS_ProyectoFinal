using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private Volume volumeObject;
    [SerializeField] private Volume[] boxesVolume;

    private void Awake()
    {
        if (boxesVolume.Length == 0)
            Debug.LogError("Falta añadir objetos a " + gameObject.name);
        else
            ActivateAllBoxes();
    }
    private void ActivateAllBoxes()
    {
        for (int i = 0; i < boxesVolume.Length; i++)
            boxesVolume[i].gameObject.SetActive(true);
    }
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
