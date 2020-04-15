using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HitScanBullet
{
    public static void ShootHitScan(Vector3 shootPosition, Vector3 shootDirection)
    {
        Ray ray = new Ray(shootPosition, shootDirection);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            Target target = hit.collider.GetComponent<Target>();

            // If the object hit has a target component
            if(target != null)
            {
                // Take damage
                target.TakeDamage(5);
            }
        }
    }

}
