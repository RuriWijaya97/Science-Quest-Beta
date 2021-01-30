using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koin : MonoBehaviour
{
    public int coinValue;
    private void OnTriggerEnter2D(Collider2D coll)
    {
       if (coll.gameObject.CompareTag("Player")) {
        ScoreManager.instance.ChangeScore(coinValue);
        
       }
    }
}
