using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(HeroAnimator))]
public class Hero : MonoBehaviour
{
    private int _maxHealth = 50;
    private int _health;
    private int _theNumberAtWhichHealthEnd = 0;
    private HeroAnimator _animation;

    private void Start()
    {
        _animation = GetComponent<HeroAnimator>();
        _health = _maxHealth;
    }

    private void ReactionOnAction(int value)
    {
        if(_health + value <= _maxHealth && _health > _theNumberAtWhichHealthEnd)
        {
            _health += value;
            _animation.Play(value, _health);
        }
    }   
}
