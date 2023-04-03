using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    [SerializeField] Text _scoring;
    [SerializeField] private Items _items;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            _items._nbCoins ++;
            _scoring.text = "" + _items._nbCoins;

            gameObject.SetActive(false);
        }
    } 
}
