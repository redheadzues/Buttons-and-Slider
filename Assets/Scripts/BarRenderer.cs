using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class BarRenderer : MonoBehaviour
{
    [SerializeField] private float _barChangeSpeed;

    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    public void ChangeBarValue(float value)
    {
        float currentValue = _slider.value + value;
        StartCoroutine(ChangeValue(currentValue));
    }

    private IEnumerator ChangeValue(float targetValue)
    {
        var waitingTime = new WaitForSeconds(0.2f);

        while (_slider.value != targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, _barChangeSpeed);

            yield return waitingTime;
        }
    }
}
