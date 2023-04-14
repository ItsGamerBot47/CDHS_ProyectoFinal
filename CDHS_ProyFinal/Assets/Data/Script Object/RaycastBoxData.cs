using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Raycast Creation/Raycast Box/RaycastBoxData")]
public class RaycastBoxData : ScriptableObject
{
    [SerializeField] private Vector3 raycastBoxSize;
    public Vector3 GetBoxSize()
    {
        return raycastBoxSize;
    }
}
