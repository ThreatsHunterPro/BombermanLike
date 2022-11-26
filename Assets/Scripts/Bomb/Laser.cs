using System;
using System.Timers;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float scaleZ = 0.0f;

    [SerializeField, Range(0.0f, 60.0f)]
    private float lifeSpan = 2.0f;
    
    [SerializeField, Range(0.0f, 100.0f)]
    private float range = 3.0f;

    [SerializeField]
    private LayerMask destroyableLayer = 0;

    private void Start()
    {
        scaleZ = transform.localScale.z;
        Resize(range);
        CheckForResize();
        InvokeRepeating(nameof(CheckDestroyable), 0.0f, 0.1f);
        Destroy(gameObject, lifeSpan);
    }

    private void Resize(float _distance)
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, scaleZ * _distance);
    }
    private void CheckForResize()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit _hitResult, range))
        {
            range = _hitResult.distance;
            if (destroyableLayer.IsEquals(_hitResult.transform.gameObject.layer)) return;
            Resize(_hitResult.distance);
        }
    }
    private void CheckDestroyable()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit _hitResult, range, destroyableLayer))
        {
            print(_hitResult.transform.gameObject.name);
            Destroy(_hitResult.transform.gameObject);
        }
    }
}
