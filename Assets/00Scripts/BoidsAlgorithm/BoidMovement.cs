using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BoidMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed =5f;
    [SerializeField] private ListBoidVariable boids;
    private float turnSpeed = 10f;
    private float radius = 2f;
    private float visionAngle = 270f; //270-degree view of the boid
    public Vector3 Velocity {  get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void FixedUpdate()
    {
        //Vector3 forwardXY = new Vector3(transform.right.x, transform.right.y, 0).normalized;
        Velocity = Vector2.Lerp(Velocity, CaculateVelocity(), turnSpeed / 2 * Time.fixedDeltaTime);
       
        this.transform.position += Velocity * Time.fixedDeltaTime;
        
        LookRotation();
    }
    private Vector2 CaculateVelocity()
    {
        var boidsInRange = BoidsInRange();
        Vector2 velocity = ((Vector2)transform.forward + 1.7f *Separation(boidsInRange)
            + 0.1f *Alignment(boidsInRange )+ Cohesion(boidsInRange)).normalized*moveSpeed;
        return velocity;
    }
    private void LookRotation()
    {
        this.transform.rotation = Quaternion.Slerp(transform.localRotation, Quaternion.LookRotation(Velocity),turnSpeed * Time.fixedDeltaTime);
       
    }
    private  List<BoidMovement> BoidsInRange(){
        var list = boids.boidMovements.FindAll(boid => boid !=this 
        && (boid.transform.position - transform.position).magnitude <= radius
        && InVisionCone(boid.transform.position));
        return list;
    }

    private bool InVisionCone(Vector2 position) // Calculate the vector from the object to its position.
    {
       Vector2 directionToPosition = position - (Vector2)transform.position; 
        float dotProduct = Vector2.Dot(transform.forward,directionToPosition);
        float cosHalfVisionAngle = Mathf.Cos(visionAngle *0.5f *  Mathf.Deg2Rad);
        return dotProduct >= cosHalfVisionAngle;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);

        var boidsInRange = BoidsInRange();
        foreach (var boid in boidsInRange)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, boid.transform.position);
        }
    }
    private Vector2 Separation(List<BoidMovement> boids) // Separation: sự tách biệt
    {
        Vector2 direction = Vector2.zero;
        foreach (var boid in boids)
        {
            Vector3 distance = boid.transform.position - transform.position;
            float ratio = Mathf.Clamp01(distance.magnitude / radius);
            direction -= ratio * (Vector2)distance;
        }
        return direction.normalized;
    }
    private Vector2 Alignment(List<BoidMovement> boids) // Alignment: căn chỉnh
    {
        Vector2 direction = Vector2.zero;
        foreach (var boid in boids)
        {
            direction += (Vector2)boid.Velocity;
        }
        if(boids.Count != 0) { direction /= boids.Count; }
        return direction.normalized;
    }
    private Vector2 Cohesion(List<BoidMovement> boids) // Cohesion: sự gắn kết
    {
        Vector2 direction;
        Vector2 center = Vector2.zero;

        if (boids.Count != 0)
        {
            foreach (var boid in boids) { center += (Vector2)boid.transform.position; }
            center /= boids.Count;
        }
        else center = Vector2.zero;
        direction = center - (Vector2)transform.position;
        return direction.normalized;
    }

}
