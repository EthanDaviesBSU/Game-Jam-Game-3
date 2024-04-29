using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Button choiceA;
    public Button choiceB;
    public Button choiceC;
    public Button continueButton;

    public Transform target;

    public bool isChoices;

    public Animator animator;

    private Queue<string> sentences;
    private string[] choices;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        isChoices = false;

        if(dialogue.choices.Length > 0)
        {
            isChoices = true;
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        continueButton.gameObject.SetActive(true);
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        if (sentences.Count == 3 && isChoices)
        {
            DisplayChoiceButtons();
        }


        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }

    public void DisplayChoiceButtons()
    {
        choiceA.gameObject.SetActive(true);
        choiceB.gameObject.SetActive(true);
        choiceC.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(false);

        choiceA.onClick.AddListener(delegate{OnClick(false);}); 
        choiceB.onClick.AddListener(delegate{OnClick(true);});  
        choiceC.onClick.AddListener(delegate{OnClick(false);}); 
    }

    public void OnClick(bool success)
    {
        if (success)
        {
            DisplayNextSentence();
            DisplayNextSentence();
            choiceA.gameObject.SetActive(false);
            choiceB.gameObject.SetActive(false);
            choiceC.gameObject.SetActive(false);
        }
        else
        {
            DisplayNextSentence();
            choiceA.gameObject.SetActive(false);
            choiceB.gameObject.SetActive(false);
            choiceC.gameObject.SetActive(false);
            continueButton.gameObject.SetActive(false);
            target.transform.position = new Vector3(-4.0f, 2.0f, 1.0f);
            Invoke("EndDialogue", 1.0f);
        }
    }
}
