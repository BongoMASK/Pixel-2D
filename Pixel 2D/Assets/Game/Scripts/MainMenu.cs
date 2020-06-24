﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Options() {

    }
    public void Quit() {
        Debug.Log("Quit!");
        Application.Quit();
    }
    public void Restart() {
        SceneManager.LoadScene("Level 1");
    }
    public void Continue() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Level1() {
        SceneManager.LoadScene("Level 1");
    }
    public void Claustrophobia() {
        SceneManager.LoadScene("Claustrophobia");
    }
    public void Maze() {
        SceneManager.LoadScene("Maze");
    }
    public void Survive() {
        SceneManager.LoadScene("Survive");
    }
}
