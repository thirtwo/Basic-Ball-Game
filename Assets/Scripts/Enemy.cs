using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Status")]
    public float patrolDistance;
    [Tooltip("This distance alert when player on this area")]
    public float alertDistance;
    public float targetDistance;
    public float speed;
    public Vector3 patrolStartPoint;
    public Vector3 patrolFinishPoint;
    public Transform target;
    public bool onStartPoint = true;
    public int strength;
    public Ray ray;
    public RaycastHit hit;
    public float watchDistance;

    public void Patrol(Vector3 patrolPoint)
    {

        transform.position = Vector3.MoveTowards(transform.position, patrolPoint, speed * Time.deltaTime);
    }
    public void Watch(Vector3 lookDirection, Vector3 patrolPoint)
    {
        if (Physics.Raycast(transform.position, lookDirection, out hit, watchDistance))
        {
            Debug.Log("drawing");
            Debug.DrawRay(transform.position, lookDirection, Color.red, watchDistance);
            if (hit.collider.tag == "Player")
            {
                FollowTarget();
            }

        }
        else
            Patrol(patrolPoint);
    }
    public void FollowTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

}
