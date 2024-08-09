using UnityEngine;
using TMPro;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.CounterChanged += DisplayCount;
    }

    private void OnDisable()
    {
        _counter.CounterChanged -= DisplayCount;
    }

    private void DisplayCount()
    {
        int count = _counter.Count;
        _counterText.text = count.ToString();
    }
}
