using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Raycast Creation/RaycastCreationData")]
public class RaycastCreationData : ScriptableObject
{
    [SerializeField] private float raycastDistance;
    [SerializeField] private LayerMask raycastLayer;
    public float GetDistance()
    {
        return raycastDistance;
    }
    public LayerMask GetLayer()
    {
        return raycastLayer;
    }
}
