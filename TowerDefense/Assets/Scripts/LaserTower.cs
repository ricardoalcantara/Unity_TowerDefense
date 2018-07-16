using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTower : MonoBehaviour
{
    [SerializeField]
    private float _damage;
    [SerializeField]
    private GameObject _attackPrefab;
    [SerializeField]
    private LayerMask _layerMask;

    private GameObject _attackInstance;

    private BasicTargeting _basicTargeting;
    private Vector3 _attackOffset = new Vector3(0, 0.65f, 0);

    private float _fireRate = 0.2f;
    private float _fireCooldown;

    void Start()
    {
        _basicTargeting = GetComponent<BasicTargeting>();
        _attackInstance = Instantiate(_attackPrefab, transform.position + _attackOffset, transform.rotation, transform);
        _attackInstance.SetActive(false);
    }

    void Update()
    {
        if (_basicTargeting.ShouldFire != _attackInstance.activeSelf)
        {
            _attackInstance.SetActive(_basicTargeting.ShouldFire);
        }
        if (_basicTargeting.ShouldFire && Time.time > _fireCooldown)
        {
            CheckHit();
            _fireCooldown = Time.time + _fireRate;
        }
    }

    private void CheckHit()
    {
        Ray ray = new Ray(transform.position + _attackOffset, transform.forward);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, _layerMask))
        {
            Health health = hit.transform.GetComponent<Health>();

            if (health != null)
            {
                health.Damage(_damage);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Ray ray = new Ray(transform.position + _attackOffset, transform.forward);
        Gizmos.DrawRay(ray);
    }
}
