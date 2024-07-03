using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuScript : MonoBehaviour
{
    void Awake() {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        root.Q<Button>("Start").clicked += () => LoadGame();
        root.Q<Button>("Settings").clicked += () => Debug.Log("settings button clicked");
        root.Q<Button>("Quit").clicked += () => QuitGame();
    }

    void LoadGame() {
        SceneManager.LoadScene("Level1");
    }

    void QuitGame() {
        Application.Quit();
    }
}
