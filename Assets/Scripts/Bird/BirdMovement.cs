using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _FirstHalfRotationDuration;
    [SerializeField] private float _SecondtHalfRotationDuration;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private Rigidbody2D _rb;
    [Space(20)]
    [SerializeField] private AudioClipPlayerSO _jumpAudioClip;

    public bool CanMove { get; set; } = true;

    private Vector3 _startPosition;
    private Quaternion _minRotation;
    private Quaternion _maxRotation;
    private float _timeElapsed;

    readonly private float _maxY = 4f;

    private void Start()
    {
        _startPosition = transform.position;
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);

        TranformReset();
    }

    

    private void Update()
    {
        if(CanMove && Input.GetMouseButtonDown(0) && transform.position.y <= _maxY)
        {
            Jump();
        }

        if (_timeElapsed < _FirstHalfRotationDuration)
        {
            if (transform.rotation.z > 0)
                StartRotationAnim(_FirstHalfRotationDuration);
            else
                StartRotationAnim(_SecondtHalfRotationDuration);

            _timeElapsed += Time.deltaTime;
        }
    }

    public void Jump()
    {
        _rb.velocity = Vector2.zero;
        _rb.AddForce(Vector2.up * _jumpForce);
        transform.rotation = _maxRotation;
        _timeElapsed = 0;
        _jumpAudioClip.PlayClip();
    }

    private void StartRotationAnim(float duration)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _timeElapsed / duration);
    }

    public void TranformReset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        _rb.velocity = Vector2.zero;
    }
}
