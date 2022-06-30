using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private float _barChangeSpeed;
    [SerializeField] private Hero _hero;

    private float _coroutineWaitingTime = 0.2f;
    private Slider _slider;
    private Coroutine _coroutine;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _hero.HealthChanged += ChangeBarValue;
    }

    private void OnDisable()
    {
        _hero.HealthChanged -= ChangeBarValue;
    }

    private void ChangeBarValue(float value)
    {
        float currentValue = _slider.value + value;

        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);            
        }

        _coroutine = StartCoroutine(ChangeValue(currentValue));
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
