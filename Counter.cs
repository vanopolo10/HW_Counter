using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _countDelay = 0.5f;
    
    private readonly int _leftMouseButton = 0;
    private bool _isCounting = false;
    private Coroutine _countingCoroutine;
    
    public event Action CounterChanged;

    public int Count { get; private set; }

    private void Update()
    {
        if (Input.GetMouseButtonDown(_leftMouseButton))
        {
            SwitchCountCoroutine();
        }
    }

    private void SwitchCountCoroutine()
    {
        if (_isCounting)
        {
            if (_countingCoroutine != null)
            {
                StopCoroutine(_countingCoroutine);
                _countingCoroutine = null;
            }
            _isCounting = false;
        }
        else
        {
            _countingCoroutine = StartCoroutine(IncreaseCount(_countDelay));
            _isCounting = true;
        }
    }

    private IEnumerator IncreaseCount(float delay)
    {
        var wait = new WaitForSeconds(delay);
        
        while (true)
        {
            Count++;
            CounterChanged?.Invoke();
            yield return wait;
        }
    }
}
