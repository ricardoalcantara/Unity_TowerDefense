using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTargeting : MonoBehaviour
{
    public bool showGizmos = false;
    public float range = 8f;
    public float rotationSpeed = 100f;
    public Transform target;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        Quaternion desiredRotation;

        if (distance <= range)
        {
            Vector3 direction = transform.position - target.position;
            desiredRotation = Quaternion.LookRotation(direction);
        }
        else
        {
            desiredRotation = Quaternion.LookRotation(Vector3.zero);
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
    }

    void OnDrawGizmos()
    {
        if (showGizmos)
        {
            // Draw a yellow sphere at the transform's position
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }
}
