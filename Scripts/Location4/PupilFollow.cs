using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PupilFollow : MonoBehaviour
{
    public Transform player;
    public float maxDistance = 0.1f; 
    private Vector3 initialLocalPosition;

    void Start()
    {
        initialLocalPosition = transform.localPosition;
    }

    void Update()
    {
        Vector3 direction = player.position - transform.position;
        direction.z = 0;
        
        Vector3 limitedDirection = Vector3.ClampMagnitude(direction, maxDistance);
        
        transform.localPosition = initialLocalPosition + limitedDirection;
    }
}
