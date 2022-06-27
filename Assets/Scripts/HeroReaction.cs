using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HeroReaction : MonoBehaviour
{
    private Animator _animator;
    private static int _takeHit = Animator.StringToHash("TakeHit");
    private static int _takeHeal = Animator.StringToHash("TakeHeal");
    private static int _die = Animator.StringToHash("Die");

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void AnimationHero(float health, bool isHeal)
    {
        if (health <= 0)
        {
            _animator.SetTrigger(_die);
        }
        else
        {
            if (isHeal == false)
            {
                _animator.SetTrigger(_takeHit); 
            }
            else
            {
                _animator.SetTrigger(_takeHeal);
            }
        }
    }
}
