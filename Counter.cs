using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _countDelay = 0.5f;
    
    private TextMeshProUGUI _counterText;
    private int _leftMouseButton = 0;
    private int _counter = 0;
    private bool _isCounting = false;
    private Coroutine _countingCoroutine;
    
    private void Start()
    {
        _counterText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(_leftMouseButton))
        {
            if (_isCounting)
            {
                StopCoroutine(_countingCoroutine);
                _isCounting = false;
            }
            else
            {
                _countingCoroutine = StartCoroutine(Count(_countDelay));
                _isCounting = true;
            }
        }
    }

    private IEnumerator Count(float delay)
    {
        var wait = new WaitForSeconds(delay);
        
        while (true)
        {
            DisplayCount(_counter);
            _counter++;
            yield return wait;
        }
    }

    private void DisplayCount(int count)
    {
        _counterText.text = count.ToString();
    }
}
