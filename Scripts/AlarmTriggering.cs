using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmTriggering : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _currentVolume = 0f;
    private float _targetVolume = 1f;
    private float _speed = 0.2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Thief thief))
        {
            StartCoroutine(IncreaseVolume());
        }
    }

    private IEnumerator IncreaseVolume()
    {
        _audioSource.Play();

        while (_currentVolume <= _targetVolume)
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, _targetVolume, _speed * Time.deltaTime);
            _audioSource.volume = _currentVolume;
            yield return null;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Thief thief))
        {
            StartCoroutine(LowerVolume());
        }
    }

    private IEnumerator LowerVolume()
    {
        while (_currentVolume > 0)
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, 0, _speed * Time.deltaTime);
            _audioSource.volume = _currentVolume;
            yield return null;
        }
        _audioSource.Stop();
    }
}
