using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Hero : MonoBehaviour
{
    [SerializeField] private BarRenderer _barRenderer;

    private Animator _animator;
    private static int _takeHit = Animator.StringToHash("TakeHit");
    private static int _takeHeal = Animator.StringToHash("TakeHeal");
    private static int _die = Animator.StringToHash("Die");
    private int _maxHealth = 50;
    private int _health;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _health = _maxHealth;
    }

    private void ReactionOnAction(int value)
    {
        if(_health + value <= _maxHealth && _health > 0)
        {
            _health += value;
            PlayAnimation(value);
            _barRenderer.ChangeBarValue(value);
        }
    }


    private void PlayAnimation(int value)
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
