using UnityEngine;
using System;

public class BirdCollisionDetecter : MonoBehaviour
{
    public event Action ScoreZonePassed;
    public event Action ObstacleHitDetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out ScoreZone scoreZone))
            ScoreZonePassed?.Invoke();
        else
            ObstacleHitDetected?.Invoke();
    }
}
