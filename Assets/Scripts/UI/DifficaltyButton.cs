using UnityEngine;
using UnityEngine.UI;

public class DifficaltyButton : MonoBehaviour
{
    [SerializeField] private Difficalty _difficalty;
    private Button _button;

    private void OnEnable()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClick);
    }

        private void OnDisable() => _button.onClick.RemoveListener(OnButtonClick);

    private void OnButtonClick() => PlayerData.Instance.SaveDifficaltyLevel((int)_difficalty);
}
