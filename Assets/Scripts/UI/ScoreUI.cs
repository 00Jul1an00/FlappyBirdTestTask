using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private ScoreKeeper _scoreKeeper;

    private void OnEnable() => _scoreKeeper.ScoreChanged += OnScoreChanged;

    private void OnDisable() => _scoreKeeper.ScoreChanged -= OnScoreChanged;

    private void OnScoreChanged(int score)
    {
        _scoreText.text = score.ToString();
    }
}
