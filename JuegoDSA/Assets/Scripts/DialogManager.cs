using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    private Queue<string> sentences;
    public static DialogManager instance = null;

    public Text nameText;
    public Text dialogueText;
    public Text btnText;

    public Animator animator;
    public Animator animatorDialog;
    void Start()
    {
        sentences = new Queue<string>();
        btnText = GameObject.Find("txtContinueClose").GetComponent<Text>();
    }
    public void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void startDialogue(Dialogue dialogue)
    {
       animatorDialog.SetBool("HelpOpened", false);
       animator.SetBool("isOpened",true);
       nameText.text = dialogue.name;

        sentences.Clear();


        foreach(string sentence in dialogue.sentences)
        {
            //Ponemos todas las sentences que hemos escrito en una cola
            sentences.Enqueue(sentence);
        }

        //Ahora las vamos a enseñar
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {            
            EndDialogue();
            return;
        }
        if(sentences.Count == 1)
        {
            btnText.text = "Close";
        }

        string sentece = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentece));
         
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("isOpened", false);
        MovimientoAleatorio.instance.StartMoving();
    }

}
