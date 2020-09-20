using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    private Queue<string> sentences;
    public Text dialogueText;
    public Text nameText;
    public Animator animator;
    bool isOpen = true;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue, Color color) {
        isOpen = true;
        animator.SetBool("isOpen", isOpen);
        //Debug.Log("starting convo with " + dialogue.name);
        nameText.text = dialogue.name;
        nameText.color = color;
        sentences.Clear();

        foreach(string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    IEnumerator LetterTypeAnim(string sentence) {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void DisplayNextSentence() {
        if(sentences.Count == 0) {
            EndDialogue();
            return;
        }
        
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(LetterTypeAnim(sentence));
    }

    public void EndDialogue() {
        isOpen = false;
        Debug.Log("End of conversation");
        animator.SetBool("isOpen", isOpen);
    }
}
