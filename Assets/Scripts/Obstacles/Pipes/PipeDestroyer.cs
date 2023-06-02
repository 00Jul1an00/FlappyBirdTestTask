using UnityEngine;
using System;

public class PipeDestroyer : MonoBehaviour
{
    public event Action PipeDestroyed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ScoreZone scoreZone))
        {
            scoreZone.gameObject.SetActive(false);
            PipeDestroyed?.Invoke();
        }
    }
}
