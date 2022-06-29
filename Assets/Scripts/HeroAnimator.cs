using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HeroAnimator : MonoBehaviour
{
    private Animator _animator;
    private static int _takeHit = Animator.StringToHash("TakeHit");
    private static int _takeHeal = Animator.StringToHash("TakeHeal");
    private static int _die = Animator.StringToHash("Die");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void Play(int value, int health)
    {
        if (health <= 0)
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
