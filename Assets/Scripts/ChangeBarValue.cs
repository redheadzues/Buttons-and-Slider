using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeBarValue : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _barChangeSpeed;
    [SerializeField] private float _barChangeValue;
    [SerializeField] private GameObject _hero;

    private HeroReaction _heroReaction;

    private void Start()
    {
        _heroReaction = _hero.GetComponent<HeroReaction>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {   
        float value = _slider.value + _barChangeValue;

        _heroReaction.AnimationHero(value, value > _slider.value);

        StartCoroutine(ChangeValue(value));       
    }

    private IEnumerator ChangeValue(float value)
    {
        var waitingTime = new WaitForSeconds(0.2f);

        while (_slider.value != value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, value, _barChangeSpeed);

            if (_slider.value <= 0)
            {
                _slider.maxValue = 0;
            }

            yield return waitingTime;
        }
    }
}
