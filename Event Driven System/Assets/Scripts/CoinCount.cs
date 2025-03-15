using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCount : MonoBehaviour
{

    //define and instantiate the text and the coin count.
    TMPro.TMP_Text text;
    int count;

    private void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
    }

    private void OnEnable() => Coin.onCollected += coinCollected;
    private void OnDisable() => Coin.onCollected -= coinCollected;


    // If a coin is collected, coin count increments by one.
    void coinCollected()
    {

        text.text = (++count).ToString();
    }

}
