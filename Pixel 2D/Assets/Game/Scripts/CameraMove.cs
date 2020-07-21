using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public List<Transform> targets;
    public Vector3 offset;
    public float smoothTime = 0.5f;

    public float minZoom;
    public float maxZoom;
    private Vector3 velocity;

    void Start()
    {
        
    }

    void Update()
    {
        if(targets.Count == 0) {
            return;
        }
        Move();
        Debug.Log(GetCenterPoint());
        Zoom();
    }

    void Zoom() {
        Debug.Log(GreatestDistance());
    }

    void Move() {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;
        transform.position = newPosition;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    float GreatestDistance() {
        var bounds = new Bounds(targets[0].position, Vector2.zero);
        for(int i = 0; i <= targets.Count; i++) {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.size.x;
    }

    Vector3 GetCenterPoint() {
        if(targets.Count == 1) {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector2.zero);
        for(int i = 0; i <= targets.Count; i++) {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }
}
