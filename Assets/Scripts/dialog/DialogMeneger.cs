using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogMeneger : MonoBehaviour
{
    public Text dialogText;
    public Text nameText;

    public Animator boxAnim;
    public Animator startAnim;

    private Queue<string> sentences;
    public GameObject dupa;
    public GameObject dialog;
    public GameObject startDialog;
    public GameObject dupsSword;
    private bool dropped;

    private void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialog(Dialog dialog)
    {
        boxAnim.SetBool("boxOpen", true);
        startAnim.SetBool("startOpen", false);
        nameText.text = dialog.name;
        sentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentences();
    }

    public void DisplayNextSentences()
    {
        if (sentences.Count == 0)
        {
            if (!dropped)
            {
                dupa.transform.GetComponent<spawn>().SpawnDroppedItem();
                dropped = true;
                Destroy(dupsSword);
            }
            EndDialog();
            dialog.SetActive(false);
            startDialog.SetActive(false);
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return null;
        }
    }

    public void EndDialog()
    {
        boxAnim.SetBool("boxOpen", false);
        
    }
} 
