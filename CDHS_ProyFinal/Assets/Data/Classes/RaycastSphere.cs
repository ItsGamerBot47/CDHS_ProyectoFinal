using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastSphere : RaycastCreation
{
    [SerializeField] private RaycastSphereData sphereData;
    public RaycastSphereData GetSphereData()
    {
        return sphereData;
    }
    public override bool ReturnRaycast(GameObject objectAttached)
    {
        return (Physics.SphereCast(objectAttached.transform.position, sphereData.GetRadius(), objectAttached.transform.forward, out sphereData.hit, raycastData.GetDistance(), raycastData.GetLayer()));
    }
}
