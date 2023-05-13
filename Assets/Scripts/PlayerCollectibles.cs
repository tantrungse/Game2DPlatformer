using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class PlayerCollectibles : MonoBehaviour
{
    private TMP_Text textComponent;
    public int gemNumber;
    void Start()
    {
        gemNumber = PlayerPrefs.GetInt("GemNumber", 0);
        textComponent = GameObject.FindGameObjectWithTag("GemUI").GetComponentInChildren<TMP_Text>();
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
