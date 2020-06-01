using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public string sceneName;

    private bool humanPlayer = false;
    private bool spiritPlayer = false;

    // Update is called once per frame
    void Update()
    {
        if(humanPlayer && spiritPlayer)
        {
            SceneManager.LoadScene(sceneName);   
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 8)
        {
            humanPlayer = true;
        }

        if (other.gameObject.layer == 9)
        {
            spiritPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            humanPlayer = false;
        }

        if (other.gameObject.layer == 9)
        {
            spiritPlayer = false;
        }
    }
}
