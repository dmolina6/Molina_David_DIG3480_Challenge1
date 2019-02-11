using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstacleController : MonoBehaviour
{
    
    public Vector3 startMarker;
    public Vector3 endMarker;
    private Vector3 Marker;
    
    
    public float speed = 1.0F;
    

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    void Start()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker, endMarker);

        Marker = endMarker;
    }

    // Follows the target position like with a spring
    void Update()
    {
        // Distance moved = time * speed.
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed = current distance divided by total distance.
        float fracJourney = distCovered / journeyLength;

        if (transform.position == endMarker)
        {
            Marker = startMarker;
        }
        else if (transform.position == startMarker)
        {
            Marker = endMarker;
        }

        // Update position
        transform.position = Vector3.Lerp(transform.position, Marker, speed * Time.deltaTime);

    }   
}