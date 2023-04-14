using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Raycast Creation/Raycast Sphere/RaycastSphereData")]
public class RaycastSphereData : ScriptableObject
{
    [SerializeField] private float raycastRadiusSize;
    public RaycastHit hit;
    public float GetRadius()
    {
        return raycastRadiusSize;
    }
}
