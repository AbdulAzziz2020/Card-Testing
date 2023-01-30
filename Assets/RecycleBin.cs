using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecycleBin : MonoBehaviour
{
    public List<int> dummyCardId = new List<int>();
    public TMP_Text Text;

    private int temp = 0;

    private void Start()
    {
        Text.text = temp.ToString();
    }

    public void GoingToRecycle(int cardId)
    {
        dummyCardId.Add(cardId);
        temp++;
        Text.text = temp.ToString();
    }
}
