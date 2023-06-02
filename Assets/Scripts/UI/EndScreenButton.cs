using UnityEngine;
using UnityEngine.UI;

public class EndScreenButton : MonoBehaviour
{
    private Button _button;

    private void OnEnable()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable() => _button.onClick.RemoveListener(OnButtonClick);

    private void OnButtonClick() => GameSceenManager.Instance.LoadMainMenuSceen();
}
