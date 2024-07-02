using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenuScript : MonoBehaviour
{

    VisualElement pauseMenu;
    bool isPaused = false;

    void Awake() {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        pauseMenu = root.Q<VisualElement>("Background");
        root.Q<Button>("ResumeButton").clicked += () => OnPause();
        root.Q<Button>("MainMenuButton").clicked += () => QuitToMainMenu();
    }

    void Update() {
        if (isPaused) {
            pauseMenu.style.display = DisplayStyle.Flex;
            Time.timeScale = 0;
        } else {
            pauseMenu.style.display = DisplayStyle.None;
            Time.timeScale = 1;
        }
    }

    void QuitToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    void OnPause() {
        isPaused = !isPaused;
    }
}
