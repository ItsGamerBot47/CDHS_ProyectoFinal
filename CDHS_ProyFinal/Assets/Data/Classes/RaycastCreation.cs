using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCreation : MonoBehaviour
{
    [SerializeField] protected RaycastCreationData raycastData;
    public RaycastCreationData GetData()
    {
        return raycastData;
    }
    public virtual bool ReturnRaycast(GameObject objectAttached) { return default; }
}