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

    public void Patrol(Vector3 patrolPoint)
    {
        
            transform.position = Vector3.MoveTowards(transform.position, patrolPoint, speed * Time.deltaTime);
    }

}
