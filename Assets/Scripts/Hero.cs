using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Hero : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private Animator _animator;
    private static int _takeHit = Animator.StringToHash("TakeHit");
    private static int _takeHeal = Animator.StringToHash("TakeHeal");
    private static int _die = Animator.StringToHash("Die");
    private int _maxHealth = 50;
    private int _health;
    private DrawBar _healthBar;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _healthBar = _slider.GetComponent<DrawBar>();
        _health = _maxHealth;
    }

    public void ReactionOnAction(int value)
    {
        if(_health + value <= _maxHealth)
        {
            _health += value;
            Animation(value);
            DrawHealth(value);
        }
    }

    private void DrawHealth(int value)
    {
        _healthBar.ChangeBarValue(value);
    }

    private void Animation(int value)
    {
        if(_health <= 0)
        {
            _animator.SetTrigger(_die);
        }
        else
        {
            if (value > 0)
                _animator.SetTrigger(_takeHeal);
            else
                _animator.SetTrigger(_takeHit);
        }
    }
}
