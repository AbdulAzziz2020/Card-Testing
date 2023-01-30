using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int cardId;
    public TMP_Text textCardId;
    
    [SerializeField] private RecycleBin _recycleBin;
    [SerializeField] private CardManager _cardManager;
    [SerializeField] private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _recycleBin = GameObject.FindObjectOfType<RecycleBin>();
        _cardManager = GameObject.FindObjectOfType<CardManager>();
        textCardId.text = "Card";
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _rectTransform.sizeDelta = new Vector2(280f, 380f);
        textCardId.text = cardId.ToString();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _rectTransform.sizeDelta = new Vector2(250f, 350f);
        textCardId.text = "Card";
    }

    public void SendToRecycleBin()
    {
        _recycleBin.GoingToRecycle(cardId);
        _cardManager.Cards.Remove(this);
        Destroy(gameObject);
    }
}
