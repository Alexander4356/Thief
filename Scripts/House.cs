using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _currentVolume = 0f;
    private float _speed = 0.2f;
    private float _targetVolume;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ThiefMover mover))
        {
            _targetVolume = 1;
            _audioSource.Play();
            StartCoroutine(VolumeChange(_targetVolume));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ThiefMover mover))
        {
            _targetVolume = 0;
            StartCoroutine(VolumeChange(_targetVolume));
            _audioSource.Stop();
        }
    }

    private IEnumerator VolumeChange(float targetVolume)
    {
        while (_currentVolume != targetVolume)
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, targetVolume, _speed * Time.deltaTime);
            _audioSource.volume = _currentVolume;
            yield return null;
        }
    }
}
