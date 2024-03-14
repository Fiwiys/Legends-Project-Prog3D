using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPoints : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float walkSpeed;

    private int currentPatrolPoint = 0;

    private void Start()
    {
        StartCoroutine(PatrolRoutine());
    }

    private IEnumerator PatrolRoutine()
    {
        while (true)
        {
            Vector3 moveToPoint = patrolPoints[currentPatrolPoint].position;
            transform.position = Vector3.MoveTowards(transform.position, moveToPoint, walkSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, moveToPoint) < 0.01f)
            {
                currentPatrolPoint = (currentPatrolPoint + 1) % patrolPoints.Length;
                yield return new WaitForSeconds(1f); // Wait for a second at each patrol point
            }

            yield return null;
        }
    }
}
