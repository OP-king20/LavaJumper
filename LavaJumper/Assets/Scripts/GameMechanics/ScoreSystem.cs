using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField]
    int score = 0;

    [SerializeField]
    Vector3 _lastPosition;

    // Use this for initialization
    void Start()
    {
        _lastPosition = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.transform.position.y > _lastPosition.y)
        {
            score++;
            print(score);
            _lastPosition = this.transform.position;
        }
    }

    //void OnGUI()
    //{
    //    GUILayout.Label("Score : " + score);
    //}

    //private void OnTriggerEnter2D(Collider2D coincol)
    //{
    //    if (coincol.gameObject.tag == "Player")
    //    {

    //        Coins = Coins +1;
    //        Debug.Log(Coins);
    //        Destroy(gameObject);
    //    }
    //}

}
