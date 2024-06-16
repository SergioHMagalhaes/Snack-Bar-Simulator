using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{
    public string npcName;
    public string[] dialogueLines;
    private int currentLineIndex;
    public GameObject dialogueUI;
    public Text dialogueText;
    public Text npcNameText;

    private void Start()
    {
        dialogueUI.SetActive(false);
    }

    public void StartDialogue()
    {
        currentLineIndex = 0;
        npcNameText.text = npcName; // Define o texto do nome do NPC
        ShowNextLine();
    }

    public void ShowNextLine()
    {
        if (currentLineIndex < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLineIndex];
            dialogueUI.SetActive(true);
            currentLineIndex++;
        }
        else
        {
            EndDialogue();
        }
    }

    public void EndDialogue()
    {
        dialogueUI.SetActive(false);
    }
}
