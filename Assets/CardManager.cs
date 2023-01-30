using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CardManager : MonoBehaviour
{
    public int minCard, maxCard;
    public Card card;
    public List<Card> Cards = new List<Card>();

    public List<int> cardId;
    private int rand;
    private RecycleBin _recycleBin;

    [Header("Deck")] 
    public Transform cardContainer;
    public TMP_Text cardAmount;

    private void Awake()
    {
        _recycleBin = GameObject.FindObjectOfType<RecycleBin>();
    }

    private void Start()
    {
        InitCard();
    }

    public void InitCard()
    {
        if (cardId.Count == 0)
        {
            cardId = new List<int>(new int[maxCard]);

            for (int i = 0; i < maxCard; i++)
            {
            
                rand = Random.Range(minCard, maxCard + 1);

                while (cardId.Contains(rand))
                {
                    rand = Random.Range(minCard, maxCard + 1);
                }

                cardId[i] = rand;

                cardAmount.text = $"Card in Deck <size=24><color=green>{cardId.Count}</color></size>";
            }
        
            BeginCard();
        }
    }

    public void BeginCard()
    {
        if (cardId.Count == maxCard && Cards.Count <= 5)
        {
            ShowCard();
        }
    }

    public void ShowCard()
    {
        if (Cards.Count <= 5 && cardId.Count != 0)
        {
            ClearingCard();

            if (cardId.Count <= 5)
            {
                for (int i = 0; i <= cardId.Count; i++)
                {
                    Card c = Instantiate(card, cardContainer);
                    int temp = Random.Range(0, cardId.Count);

                    if (!cardId.Contains(temp))
                    {
                        temp = Random.Range(0, cardId.Count);
                    }
            
                    c.cardId = cardId[temp];
                    Cards.Add(c);
                    cardId.Remove(cardId[temp]);

                    cardAmount.text = $"Card in Deck <size=24><color=green>{cardId.Count}</color></size>";
                }
            }
            
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    Card c = Instantiate(card, cardContainer);
                    int temp = Random.Range(0, cardId.Count);

                    if (!cardId.Contains(temp))
                    {
                        temp = Random.Range(0, cardId.Count);
                    }
            
                    c.cardId = cardId[temp];
                    Cards.Add(c);
                    cardId.Remove(cardId[temp]);
                    
                    cardAmount.text = $"Card in Deck <size=24><color=green>{cardId.Count}</color></size>";
                }
            }
        }
    }
    
    private void ClearingCard()
    {
        for (int i = 0; i < Cards.Count; i++)
        {
            Destroy(Cards[i].gameObject);
            _recycleBin.GoingToRecycle(Cards[i].cardId);
            
            cardAmount.text = $"Card in Deck <size=24><color=green>{cardId.Count}</color></size>";
        }
        
        Cards.Clear();
    }

    public void Reset()
    {
        if (cardId != null)
        {
            for (int i = 0; i < cardId.Count; i++)
            {
                _recycleBin.GoingToRecycle(cardId[i]);
                
            }
            
            cardAmount.text = $"Card in Deck <size=24><color=green>{cardId.Count}</color></size>";
            cardId.Clear();
            ClearingCard();
        }
    }
}
