using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPauseGame;
    [SerializeField] private GameObject menuWinGame;

    public void PauseGame()
    {
        Time.timeScale = 0;
        menuPauseGame.SetActive(true);
    } 

    public void ResumeGame()
    {
        Time.timeScale = 1;
        menuPauseGame.SetActive(false);
    }

    public void ResetGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void WinGame()
    {
        Time.timeScale = 0;
        menuWinGame.SetActive(true);
    } 
        
}
