using UnityEngine;
using UnityEngine.EventSystems;

public class StartGameTouch : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private BirdMovement _birdMovement;
    [SerializeField] private Rigidbody2D _birdRb;
    [SerializeField] private PipeMover _pipeMover;

    private void Awake()
    {
        _pipeMover.gameObject.SetActive(false);
        _birdMovement.enabled = false;
        _birdRb.Sleep();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _birdRb.WakeUp();
        _birdMovement.enabled = true;
        _birdMovement.Jump();
        _pipeMover.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
