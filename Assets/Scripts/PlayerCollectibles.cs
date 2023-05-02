using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class PlayerCollectibles : MonoBehaviour
{
    public TMP_Text textComponent;
    public int gemNumber;
    void Start()
    {
        UpdateText();
    }


    void Update()
    {
        
    }

    void UpdateText()
    {
        textComponent.text = gemNumber.ToString();
    }

    public void GemCollected()
    {
        gemNumber++;
        UpdateText();
    }
}
