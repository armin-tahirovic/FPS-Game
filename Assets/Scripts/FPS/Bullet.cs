using System.Collections;
using System.Collections.Generic;
using FPS;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed;
    
    public void Chase(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        var distanceFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceFrame)
        {
            HitTarget();
        }
        
        transform.Translate(direction.normalized * distanceFrame, Space.World);
    }

    void HitTarget()
    {
        GameManager.CurrentHealth -= 18;
        Destroy(gameObject);
    }
}
