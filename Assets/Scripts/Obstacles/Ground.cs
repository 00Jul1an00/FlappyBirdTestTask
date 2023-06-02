using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private BirdCollisionDetecter _birdCollisionDetecter;

    private void OnEnable() => _birdCollisionDetecter.ObstacleHitDetected += OnObstacleHitDetected;
    private void OnDisable() => _birdCollisionDetecter.ObstacleHitDetected -= OnObstacleHitDetected;

    private void OnObstacleHitDetected()
    {
        string parametr = _animator.parameters[0].name;
        _animator.SetBool(parametr, true);
    }
}
