using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndScreenPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _highScoreText;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private ScoreKeeper _scoreKeeper;

    private void OnEnable()
    {
        _scoreKeeper.ObstacleHited += OnObstacleHited;
        _mainMenuButton.onClick.AddListener(OnMenuButtonClick);
    }

    private void OnDisable()
    {
        _scoreKeeper.ObstacleHited -= OnObstacleHited;
        _mainMenuButton.onClick.RemoveListener(OnMenuButtonClick);
    }

    private void OnObstacleHited()
    {
        _scoreText.text = _scoreKeeper.Score.ToString();
        _highScoreText.text = _scoreKeeper.HighScore.ToString();
    }

    private void OnMenuButtonClick()
    {

    }
}
