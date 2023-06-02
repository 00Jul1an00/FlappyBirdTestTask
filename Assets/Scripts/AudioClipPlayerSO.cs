using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioClipPlayerSO", menuName = "ScriptableOjects/AudioClipPlayerSO", order = 1)]
public class AudioClipPlayerSO : ScriptableObject
{
    [SerializeField] private AudioClip _clip;
    [SerializeField] private float _clipVolume;

    public void PlayClip()
    {
        AudioSource source;
        var obj = new GameObject(typeof(AudioSource).ToString(), typeof(AudioSource));
        source = obj.GetComponent<AudioSource>();
        source.clip = _clip;
        source.volume = _clipVolume;
        source.pitch = 1;
        source.Play();
        Destroy(source.gameObject, source.clip.length);
    }
}
