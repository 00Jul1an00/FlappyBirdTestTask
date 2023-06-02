using UnityEngine;

[RequireComponent(typeof(PipeSpawner))]
public class PipeMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private BirdCollisionDetecter _birdCollisionDetecter;

    private bool _canMove = true;
    private PipeSpawner _pipeSpawner;

    private readonly int _moveDirectionMul = -1;

    private void Start() => _pipeSpawner = GetComponent<PipeSpawner>();

    private void OnEnable() => _birdCollisionDetecter.ObstacleHitDetected += OnObstacleHitDetected;

    private void OnDisable() => _birdCollisionDetecter.ObstacleHitDetected -= OnObstacleHitDetected;

    private void Update()
    {
        if(_canMove)
            _pipeSpawner.transform.position += new Vector3(_speed * Time.deltaTime, 0) * _moveDirectionMul;
    }

    private void OnObstacleHitDetected()
    {
        _canMove = false;
    }
}
