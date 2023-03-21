using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    [SerializeField] Text _scoring;
    int _score = 0;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            _score ++;
            _scoring.text = "" + _score;
            Destroy(gameObject);
        }
    }
}
