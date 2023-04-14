using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    [SerializeField] private float speedBullet = 10.0f;
    [SerializeField] private float movingTime = 2.0f;
    private RaycastSphere raycastInfo;
    private float totalTime = 0;
    private RaycastHit hit;

    private void Awake()
    {
        raycastInfo = GetComponent<RaycastSphere>();
        if (raycastInfo == null)
            Debug.LogError("Falta scrip RaycastSphere en " + gameObject.name + ".");
    }
    private void FixedUpdate()
    {
        MovingBullet();
    }

    private void MovingBullet()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speedBullet, Space.Self);
        if (BulletCheckByRaycast() || BulletCheckByTime())
            Destroy(this.gameObject);
    }
    private bool BulletCheckByRaycast()
    {
        return raycastInfo.ReturnRaycast(gameObject);
    }
    private bool BulletCheckByTime()
    {
        totalTime += Time.deltaTime;
        return (totalTime > movingTime);
    }
}
