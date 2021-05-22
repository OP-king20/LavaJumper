using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartSystem : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D restart)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
