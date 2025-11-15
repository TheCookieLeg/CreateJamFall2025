using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class NoteBookButtonScript : MonoBehaviour
{

    public Button button;
    public Shadow shadow;
    public GameObject noteBookPanel;
    private bool isNoteBookOpen = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
        shadow = button.GetComponent<Shadow>(); //Get shadow component from button

        isNoteBookOpen = false;


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.S))
        {
            
            button.onClick.Invoke(); //Simulate button click
            shadow.effectDistance = new Vector2(3, -3); //Change shadow to pressed state
            

            if (!isNoteBookOpen)
            {
                OpenNoteBook();
                isNoteBookOpen = true;
            }
            else
            {
                CloseNoteBook();
                isNoteBookOpen = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            shadow.effectDistance = new Vector2(1, -1); // normal
        }
    }

    // Remove static so it can access instance fields
    void OpenNoteBook()
    {
        if (noteBookPanel != null)
        {
            noteBookPanel.SetActive(true); // Show the notebook panel
        }   
    }

    void CloseNoteBook()
    {
        if (noteBookPanel != null)
        {
            noteBookPanel.SetActive(false); // Show the notebook panel
        }
    }

}
