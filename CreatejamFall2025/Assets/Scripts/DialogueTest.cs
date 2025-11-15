using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTest : MonoBehaviour
{
    
    [SerializeField] private Button dialogueButton;
    [SerializeField] private GameObject buttonPanel;
    private Button button1;
    private Button button2;
    private Button button3;
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int textIndex;
    private bool isTyping;
    void Start()
    {
        showChoice("Option 1", "Option 2", "Option 3");
        textComponent.text = "";
        startDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                textComponent.text = lines[textIndex];
                isTyping = false;
            }
            else
            {
                NextLine();
            }
        }
    }

    private void startDialogue()
    {
        textIndex = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        foreach (char c in lines[textIndex].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;
    }

    void NextLine()
    {
        if (textIndex < lines.Length - 1)
        {
            textIndex++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    private void showChoice(string button1txt, string button2txt = null, string button3txt = null)
    {
        button1 = Instantiate(dialogueButton, buttonPanel.transform, false);
        button1.GetComponentInChildren<TextMeshProUGUI>().text = button1txt;
        if (button2txt != null)
        {
            button2 = Instantiate(dialogueButton, buttonPanel.transform, false);
            button2.GetComponentInChildren<TextMeshProUGUI>().text = button2txt;
        }
        if (button3txt != null)
        {
            button3 = Instantiate(dialogueButton, buttonPanel.transform, false);
            button3.GetComponentInChildren<TextMeshProUGUI>().text = button3txt;
        }
    }
}
