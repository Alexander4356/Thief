using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _targetVolume;
    private float _currentVolume = 0f;
    private float _speed = 0.2f;
    private bool _start = false;

    public void IncreseVolume()
    {
        _targetVolume = 1f;

        if (_start != true)
        {
            _start = true;
            _audioSource.Play();
            StartCoroutine(ChangeVolume(_targetVolume));
            _start = false;
        }
    }

    public void LowerVolume()
    {
        _targetVolume = 0f;

        if (_start != true)
        {
            _start = true;
            StartCoroutine(ChangeVolume(_targetVolume));
            _start = false;
        }

        if (_audioSource.volume == 0)
        {
            _audioSource.Stop();
        }
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        while (_currentVolume != _targetVolume)
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, targetVolume, _speed * Time.deltaTime);
            _audioSource.volume = _currentVolume;
            yield return null;
        }
    }
}
