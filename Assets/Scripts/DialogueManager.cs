using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DialogueManager : MonoBehaviour
{

    private Queue<string> sentences;
    Label npcName;
    Label npcDialogue;
    DialogueTrigger dialogueTrigger;

    public UIDocument dialogueBox;

    void Start()
    {
        sentences = new Queue<string>();
        dialogueTrigger = dialogueBox.GetComponent<DialogueTrigger>();
        npcName = dialogueBox.rootVisualElement.Q<Label>("NPCName");
        npcDialogue = dialogueBox.rootVisualElement.Q<Label>("NPCDialogue");
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueTrigger.isVisible = true;
        Debug.Log("npcName: " + npcName.text);
        npcName.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public  void DisplayNextSentence()
    {
        if(sentences.Count == 0) {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        npcDialogue.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence) {
        npcDialogue.text = "";
        foreach(char letter in sentence.ToCharArray()) {
            npcDialogue.text += letter;
            yield return null;
        }
    }

    void EndDialogue() {
        Debug.Log("end of conversation");
        dialogueTrigger.isVisible = false;
    }
}
