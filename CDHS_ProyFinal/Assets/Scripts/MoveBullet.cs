using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    [SerializeField] private float speedBullet = 10.0f;
    [SerializeField] private float movingTime = 2.0f;
    [SerializeField] private float raycastSphereRadius;
    [SerializeField] private float raycastMaxDist;
    [SerializeField] private LayerMask raycastLayers;
    private float totalTime = 0;
    private RaycastHit hit;

    private void OnDrawGizmos()
    {
        DrawRaycast();
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
        return (Physics.SphereCast(transform.position, raycastSphereRadius, transform.forward, out hit, raycastMaxDist, raycastLayers));
    }
    private bool BulletCheckByTime()
    {
        totalTime += Time.deltaTime;
        return (totalTime > movingTime);
    }
    private void DrawRaycast()
    {
        Gizmos.DrawWireSphere(transform.position, raycastMaxDist);
        Gizmos.color = Color.red;
        Vector3 sphereCastMidpoint = transform.position + (transform.forward * (raycastMaxDist-raycastSphereRadius));
        Gizmos.DrawWireSphere(sphereCastMidpoint, raycastSphereRadius);
        Debug.DrawLine(transform.position, sphereCastMidpoint, Color.red);
    }
}
