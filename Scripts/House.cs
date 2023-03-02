using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class House : MonoBehaviour
{
    private Alarm _alarm;

    private void Start()
    {
        _alarm = GetComponentInChildren<Alarm>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ThiefMover thief))
        {
            _alarm.IncreseVolume();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ThiefMover thief))
        {
            _alarm.LowerVolume();
        }
    }
}
