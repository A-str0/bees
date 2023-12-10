using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject levelsMenu;

    public void PlayGame() {
        mainMenu.SetActive(false);
        levelsMenu.SetActive(true);
    }

    public void LoadLevel(string level) {
        SceneManager.LoadScene(level);
    }

    public void Back() {
        mainMenu.SetActive(true);
        levelsMenu.SetActive(false);
    }
}
