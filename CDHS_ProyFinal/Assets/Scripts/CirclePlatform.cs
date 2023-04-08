using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePlatform : MonoBehaviour
{
    public enum PlatformType
    {
        Movement, Teleport
    }
    [SerializeField] private PlatformType platformToShow;
    [SerializeField] private GameObject[] platformToSave;
    private Dictionary<PlatformType, GameObject> asignPlatform = new Dictionary<PlatformType, GameObject>();
    

    private void Start()
    {
        if (platformToSave.Length < 2)
            Debug.LogError("There has to be at least 2 objects in Array[] of " + gameObject + ".");

        asignPlatform.Add(PlatformType.Movement, platformToSave[0]);
        asignPlatform.Add(PlatformType.Teleport, platformToSave[1]);
    }
    private void Update()
    {
        DoPlatform();
    }

    private void DoPlatform()
    {
        switch (platformToShow)
        {
            case PlatformType.Movement:
            {
                asignPlatform[PlatformType.Movement].SetActive(true);
                asignPlatform[PlatformType.Teleport].SetActive(false);
                break;
            }
            case PlatformType.Teleport:
            {
                asignPlatform[PlatformType.Movement].SetActive(false);
                asignPlatform[PlatformType.Teleport].SetActive(true);
                break;
            }
        }
    }
}
