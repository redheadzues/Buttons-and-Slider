using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int _barChangeValue;
    [SerializeField] private GameObject _player;

    Hero _hero;

    private void Start()
    {
        _hero = _player.GetComponent<Hero>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _hero.ReactionOnAction(_barChangeValue);
    }
}
