using UnityEngine;
using System;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private BirdCollisionDetecter _birdCollisionDetecter;
    [SerializeField] private EndScreenPanel _endScreenPanel;
    [Space(20)]
    [SerializeField] private AudioClipPlayerSO _scoreAudioClip;

    public event Action<int> ScoreChanged;
    public event Action ObstacleHited;

    public int Score { get; private set; }
    public int HighScore { get; private set; }

    private void OnEnable()
    {
        HighScore = PlayerData.Instance.GetHighScore();
        _birdCollisionDetecter.ScoreZonePassed += OnScoreZonePassed;
        _birdCollisionDetecter.ObstacleHitDetected += OnObstacleHitDetected;
    }

    private void OnDisable()
    {
        _birdCollisionDetecter.ScoreZonePassed -= OnScoreZonePassed;
        _birdCollisionDetecter.ObstacleHitDetected -= OnObstacleHitDetected;
    }
    private void OnScoreZonePassed()
    {
        Score++;
        ScoreChanged?.Invoke(Score);
        _scoreAudioClip.PlayClip();
    }

    private void OnObstacleHitDetected()
    {
        if (HighScore < Score)
        {
            HighScore = Score;
            PlayerData.Instance.SaveHighScore(Score);
        }

        _endScreenPanel.gameObject.SetActive(true);
        ObstacleHited?.Invoke();
    }
}
