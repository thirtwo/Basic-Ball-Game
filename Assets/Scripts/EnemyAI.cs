using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : Enemy
{

    private void Awake()
    {
        patrolStartPoint = transform.position;
        patrolFinishPoint = transform.position + Vector3.right * patrolDistance;

    }
    private void Update()
    {
        targetDistance = Vector3.Distance(target.position, transform.position);
        if (Mathf.Abs(targetDistance) > alertDistance)
        {
            if (Mathf.Abs(Vector3.Distance(patrolStartPoint, transform.position)) < 0.2f)
            {
                onStartPoint = true;
            }
            else if (Mathf.Abs(Vector3.Distance(patrolFinishPoint, transform.position)) < 0.2f)
            {
                onStartPoint = false;
            }

        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        if (onStartPoint)
        {
            Patrol(patrolFinishPoint);
        }
        else
        {
            Patrol(patrolStartPoint);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        collision.collider.GetComponent<BallController>().TakeDamage(strength);
    }


}
