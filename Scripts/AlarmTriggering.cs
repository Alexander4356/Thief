using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmTriggering : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _currentVolume = 0f;
    private float _targetVolume;
    private float _speed = 0.2f;

    public IEnumerator IncreaseVolume()
    {
        _targetVolume = 1f;
        _audioSource.Play();

        while (_currentVolume <= _targetVolume)
        {
            VolumeChange(_targetVolume);
            yield return null;
        }
    }

    public IEnumerator LowerVolume()
    {
        _targetVolume = 0f;

        while (_currentVolume > 0)
        {
            VolumeChange(_targetVolume);
            yield return null;
        }
        _audioSource.Stop();
    }

    private void VolumeChange(float targetVolume)
    {
        _currentVolume = Mathf.MoveTowards(_currentVolume, targetVolume, _speed * Time.deltaTime);
        _audioSource.volume = _currentVolume;
    }
}
