using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    //Be sure to assign this a value in the designer.
    [SerializeField]
    int Coins;

    private void Start()
    {
        Coins = 0;
    
    }

    void Update()
    {

   
    }

    private void OnTriggerEnter2D(Collider2D coincol)
    {
        if (coincol.gameObject.tag == "Player")
        {
            
            Coins = Coins +1;
            Debug.Log(Coins);
            Destroy(gameObject);
        }
    }

}
