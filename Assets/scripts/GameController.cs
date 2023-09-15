using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //  flag to track whether the game is over.
    private bool isGameOver = false;

    // Update is called once per frame
    void Update()
    {
        // Use the "Escape" key.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Set the game over flag to true.
            isGameOver = true;

            //  method to handle the game ending.
            EndGame();
        }
    }

    // Game ending.
    void EndGame()
    {
        // Quit the application.
        Application.Quit();
    }
}