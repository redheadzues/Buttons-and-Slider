using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawBar : MonoBehaviour
{
    [SerializeField] private float _barChangeSpeed;

    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }


    public void ChangeBarValue(float value)
    {
        float _currentValue = _slider.value + value;
        StartCoroutine(ChangeValue(_currentValue));
    }

    private IEnumerator ChangeValue(float _targetValue)
    {
        var waitingTime = new WaitForSeconds(0.2f);

        while (_slider.value != _targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _barChangeSpeed);

            if (_slider.value <= 0)
            {
                _slider.maxValue = 0;
            }

            yield return waitingTime;
        }
    }
}
