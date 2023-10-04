using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerCollision : MonoBehaviour
{
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with" + collision.gameObject.name);

        //trigger dialogue box
        if (collision.gameObject.name == "Door")
        {
            SceneManager.LoadScene("LevelTwo");
        }

        if (collision.gameObject.name == "Final Door")
        {
            SceneManager.LoadScene("Main");
        }
    }
}