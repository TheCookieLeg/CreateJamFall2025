using UnityEngine;

public class SpawnCustomer : MonoBehaviour
{
    [SerializeField] private GameObject[] customerList;
    [SerializeField] private Dialogue[] dialogueList; //Instert list of dialogue in same order
    [SerializeField] private string[] nameList;
    private int currentCustomer = -1;
    public Transform stopPos;
    private GameObject car;
    private CustomerBehaviour customerBehaviour;
    //[SerializeField] private Transform spawnPos;

    public static SpawnCustomer instance; //Create singleton of script
    void Awake() 
    {
        if (instance != null && instance != this)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
        nextCustomer();
    }

    public void nextCustomer()
    {
        currentCustomer++;
        if (DialogueManager.Instance.favorList.Contains("mildred jail"))
        {
            dialogueList[7] = null;
        }
        if (DialogueManager.Instance.favorList.Contains("alfonzo jail"))
        {
            dialogueList[6] = null;
        }
        if (!(DialogueManager.Instance.favorList.Contains("wolf ring") || DialogueManager.Instance.favorList.Contains("spider ring") || DialogueManager.Instance.favorList.Contains("Lion ring")) && currentCustomer > 8)
        {
            dialogueList[9] = null;
        }
        if (DialogueManager.Instance.favorList.Contains("Dead mildred"))
        {
            dialogueList[2] = null;
            dialogueList[7] = null;
        }

        if (!DialogueManager.Instance.favorList.Contains("Extorded") && currentCustomer > 8)
        {
            dialogueList[10] = null;
        }
        if (dialogueList[currentCustomer] != null)
        {
            car = Instantiate(customerList[currentCustomer]);
            customerBehaviour = car.GetComponent<CustomerBehaviour>();
            customerBehaviour.dialogue = dialogueList[currentCustomer];
            customerBehaviour.name = nameList[currentCustomer];
        }
        else
        {
            nextCustomer();
        }
    }

    public void startDialogue()
    {
        customerBehaviour.StartDialogue();
    }

    public void endDialogue()
    {
        customerBehaviour.Despawn();
    }
}
