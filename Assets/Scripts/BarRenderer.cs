using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class BarRenderer : MonoBehaviour
{
    [SerializeField] private float _barChangeSpeed;

    private float _coroutineWaitingTime = 0.2f;
    private Slider _slider;
    private Coroutine _dontCallDuubleCoroutine;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    public void ChangeBarValue(float value)
    {
        float currentValue = _slider.value + value;

        if(_dontCallDuubleCoroutine != null)
        {
            StopCoroutine(_dontCallDuubleCoroutine);            
        }

        _dontCallDuubleCoroutine = StartCoroutine(ChangeValue(currentValue));
    }

    private IEnumerator ChangeValue(float targetValue)
    {
        var waitingTime = new WaitForSeconds(_coroutineWaitingTime);

        while (_slider.value != targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, _barChangeSpeed);

            yield return waitingTime;
        }
    }
}
