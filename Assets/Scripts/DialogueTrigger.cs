using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DialogueTrigger : MonoBehaviour
{
    
    VisualElement rootElement;
    public bool isVisible = false;

    void Awake() {
        rootElement = GetComponent<UIDocument>().rootVisualElement;
        Button continueButton = rootElement.Q<Button>("Continue");
        continueButton.clicked += () => ContinueDialogue();
    }

    void Update() {
        if(isVisible) {
            rootElement.style.display = DisplayStyle.Flex;
        } else {
            rootElement.style.display = DisplayStyle.None;
        }
    }

    public void ContinueDialogue() {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }
}
