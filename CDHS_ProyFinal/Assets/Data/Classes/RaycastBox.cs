using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastBox : RaycastCreation
{
    [SerializeField] private RaycastBoxData boxData;
    public RaycastBoxData GetBoxData()
    {
        return boxData;
    }
    public override bool ReturnRaycast(GameObject objectAttached)
    {
        return (Physics.BoxCast(objectAttached.transform.position, boxData.GetBoxSize(), -objectAttached.transform.up, objectAttached.transform.rotation, raycastData.GetDistance(), raycastData.GetLayer()));
    }
}
