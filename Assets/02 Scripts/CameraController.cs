using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform target;
    private Vector3 velocity = Vector3.zero;
    [Range(0, 1)]
    [SerializeField] private float smoothTime;
    [SerializeField] private Vector3 offset;

    private void Awake()
    {
        target = player.GetChild(0).transform;
    }
    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
