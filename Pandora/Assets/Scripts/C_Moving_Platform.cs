using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovingPlatforms : MonoBehaviour
{
    [SerializeField] private Transform centerPoint;
    [SerializeField] private float radius;
    [SerializeField] private float speed;
    [SerializeField] private float idleDuration;

    private float currentAngle = 0f;
    private float idleTimer = 0f;

    private void Update()
    {
        if (idleTimer >= idleDuration)
        {
            currentAngle += speed * Time.deltaTime;
            if (currentAngle >= 360f)
            {
                currentAngle -= 360f;
            }
            idleTimer = 0f;
        }
        else
        {
            idleTimer += Time.deltaTime;
        }

        float newX = centerPoint.position.x + Mathf.Cos(currentAngle * Mathf.Deg2Rad) * radius;
        float newZ = centerPoint.position.z + Mathf.Sin(currentAngle * Mathf.Deg2Rad) * radius;
        transform.position = new Vector3(newX, transform.position.y, newZ);
    }
}