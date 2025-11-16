using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class DialogueResponse
{
    public string responseText;
    public DialogueNode nextNode;
    //public UnityEvent unityEvent;
    public string favorTask;
    public string condition;
}
