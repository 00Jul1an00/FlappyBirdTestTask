using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _pipePrefab;
    [SerializeField] private PipeDestroyer _pipeDestroyer;
    [SerializeField] private float _maxYPipePosition;
    [SerializeField] private float _minYPipePosition;
    [SerializeField] private float _distanceBetweenPipes;
    [SerializeField] private int _startPipesCount;

    private GameObject _lastSpawnPipe;
    private ObjectPool _pool;

    private void Start()
    {
        _pool = new (_pipePrefab, _startPipesCount, transform);
        _pipeDestroyer.PipeDestroyed += OnPipeDestroyed;

        for (int i = 0; i < _startPipesCount; i++)
        {
            SetPipePosition();
        }
    }

    private void OnDisable()
    {
        _pipeDestroyer.PipeDestroyed -= OnPipeDestroyed;
    }

    private void SetPipePosition()
    {
        float posX = _distanceBetweenPipes;

        if (_lastSpawnPipe != null)
            posX += _lastSpawnPipe.transform.position.x;

        float posY = Random.Range(_minYPipePosition, _maxYPipePosition);
        Vector2 pos = new (posX, posY);
        _lastSpawnPipe = _pool.ActivateObject();
        _lastSpawnPipe.transform.position = pos;
    }

    private void OnPipeDestroyed()
    {
        SetPipePosition();
    }
}
