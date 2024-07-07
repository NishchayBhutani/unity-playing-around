using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{

    Animator animator;

    private int levelToLoad;

    public Transform playerTransform;
    public float xPositionForFade = 9f;

    void Awake() {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(playerTransform.position.x > xPositionForFade) {
           FadeToLevel(2);
        }
    }

    void FadeToLevel(int levelIndex) {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    void OnFadeComplete() {
        SceneManager.LoadScene(levelToLoad);
    }
}
