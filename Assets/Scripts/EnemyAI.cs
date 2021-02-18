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
    private void FixedUpdate()
    {
        
        if (Mathf.Abs(Vector3.Distance(patrolStartPoint, transform.position)) < 0.2f)
        {
            onStartPoint = true;
            transform.Rotate(0, 180, 0);
        }
        else if (Mathf.Abs(Vector3.Distance(patrolFinishPoint, transform.position)) < 0.2f)
        {
            onStartPoint = false;
            transform.Rotate(0, 180, 0);
        }

       
        if (onStartPoint)
        {

            Watch(Vector3.right, patrolFinishPoint);
        }
        else
        {

            Watch(Vector3.left, patrolStartPoint);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        collision.collider.GetComponent<BallController>().TakeDamage(strength);
    }


}
