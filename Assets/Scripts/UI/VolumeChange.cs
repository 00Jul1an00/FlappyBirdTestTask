using UnityEngine;
using UnityEngine.UI;

public class VolumeChange : MonoBehaviour
{
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private Button _muteButton;

    private void Start()
    {
        _volumeSlider.value = PlayerData.Instance.GetVolume();
        _muteButton.onClick.AddListener(OnMuteButtonClick);
    }

    private void OnDestroy()
    {
        _muteButton.onClick.RemoveListener(OnMuteButtonClick);
    }

    private void OnMuteButtonClick()
    {
        _volumeSlider.value = 0;
        AudioListener.volume = 0;
        PlayerData.Instance.SaveVolume(0);
    }

    public void OnSliderValueChanged(float value)
    {
        AudioListener.volume = value;
        PlayerData.Instance.SaveVolume(value);
    }
}
