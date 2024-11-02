using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puasa : MonoBehaviour
{

    public GameObject pauseMenuUI; // The UI GameObject for the pause menu
    private GameObject player;
    private bool isPaused = false;
    
    void Start()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Pause the game
        isPaused = true;
        /*
        FirstPersonController controller = player.GetComponent<FirstPersonController>();
        controller.cameraCanMove = false;
        */
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Resume normal time scale
        isPaused = false;
        //FirstPersonController controller = player.GetComponent<FirstPersonController>();
        //controller.cameraCanMove = true;
    }
}
