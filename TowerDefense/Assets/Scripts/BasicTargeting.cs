using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTargeting : MonoBehaviour
{
    [SerializeField]
    private bool showGizmos = false;
    [SerializeField]
    private float range = 8f;
    [SerializeField]
    private float rotationSpeed = 100f;
    [SerializeField]
    private Transform target;

    private Quaternion _initialRot;

    public bool ShouldFire { get; private set; }

    void Start()
    {
        _initialRot = transform.rotation;
    }

    void Update()
    {
        Quaternion desiredRotation = _initialRot;

        if (target != null)
        {
            float distance = Vector3.Distance(transform.position, target.position);

            if (distance <= range)
            {
                ShouldFire = true;
                Vector3 direction = target.position - transform.position;
                desiredRotation = Quaternion.LookRotation(direction);
            }
            else
            {
                ShouldFire = false;
            }
        }
        else
        {
            ShouldFire = false;
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
