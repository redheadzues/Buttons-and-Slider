using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(HeroAnimator))]
public class Hero : MonoBehaviour
{
    [SerializeField] public UnityEvent<float> HealthChanged;

    private int _maxHealth = 50;
    private int _health;
    private int _theNumberAtWhichHealthEnd = 0;
    private HeroAnimator _animation;

    private void Start()
    {
        _animation = GetComponent<HeroAnimator>();
        _health = _maxHealth;
    }

    public void ChangeHealth(int value)
    {
        if(_health > 0)
        {
            _health = Mathf.Clamp(_health + value, _theNumberAtWhichHealthEnd, _maxHealth);
            _animation.Play(value, _health);
            HealthChanged?.Invoke(value);
        }        
    }   
}

