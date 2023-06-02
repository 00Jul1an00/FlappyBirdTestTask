using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private Button _startButton;

    private void Start()
    {
        _startButton = GetComponent<Button>();
        _startButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable() => _startButton.onClick.RemoveListener(OnButtonClick);

    private void OnButtonClick () => GameSceenManager.Instance.LoadChosenLevel();
}
