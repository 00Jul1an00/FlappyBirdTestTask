using UnityEngine;

[RequireComponent(typeof(BirdCollisionDetecter), typeof(BirdMovement))]
public class Bird : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioClipPlayerSO _hitAudioClip;

    private BirdMovement _birdMovement;
    private BirdCollisionDetecter _birdCollisionDetecter;

    private bool _firstHit = true;

    private void Start()
    {
        _birdMovement = GetComponent<BirdMovement>();
        _birdCollisionDetecter = GetComponent<BirdCollisionDetecter>();
        _birdCollisionDetecter.ObstacleHitDetected += OnObstacleHitDetected;
    }

    private void OnDisable()
    {
        _birdCollisionDetecter.ObstacleHitDetected -= OnObstacleHitDetected;
    }

    private void OnObstacleHitDetected()
    {
        if (!_firstHit)
            return;

        _birdMovement.CanMove = false;
        string parametr = _animator.parameters[0].name;
        _animator.SetBool(parametr, true);
        _hitAudioClip.PlayClip();
        _firstHit = false;
    }
}
