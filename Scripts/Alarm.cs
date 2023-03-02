using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _targetVolume;
    private float _currentVolume = 0f;
    private float _speed = 0.2f;
    private Coroutine _currentCoroutine;

    public void IncreseVolume()
    {
        _targetVolume = 1f;
        _audioSource.Play();

        CheckCoroutine();
        _currentCoroutine = StartCoroutine(ChangeVolume(_targetVolume));
    }

    public void LowerVolume()
    {
        _targetVolume = 0f;

        CheckCoroutine();
        _currentCoroutine = StartCoroutine(ChangeVolume(_targetVolume));

        if (_audioSource.volume == 0)
        {
            _audioSource.Stop();
        }
    }

    private void CheckCoroutine()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
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
