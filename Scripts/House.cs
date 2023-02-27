using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    private AlarmTriggering _alarmTriggering;

    private void Start()
    {
        _alarmTriggering = GetComponent<AlarmTriggering>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ThiefMover mover))
        {
            StartCoroutine(_alarmTriggering.IncreaseVolume());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ThiefMover mover))
        {
            StartCoroutine(_alarmTriggering.LowerVolume());
        }
    }
}
