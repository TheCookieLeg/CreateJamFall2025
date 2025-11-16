using UnityEngine;

public class CustomerBehaviour : MonoBehaviour
{
    private Transform points;
    
    [SerializeField] private float lerp;
    [SerializeField] private float carTimer;
    [SerializeField] private float carSpeed;
    private float currentSpeed;
    private bool dialogueStarted = false;
    [SerializeField] private bool dialogueDone = false;
    private Vector3 carDir;
    private SpawnCustomer spawnCustomer;
    public Dialogue dialogue;
    private DialogueManager dialogueManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        points = SpawnCustomer.instance.stopPos;
        carDir = (points.position - transform.position).normalized;
        currentSpeed = carSpeed;
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, points.position) >= 0.2f && !dialogueDone && points != null)
        {
            if (Vector3.Distance(transform.position, points.position) <= 100f)
            {
                currentSpeed -= 0.8f * Time.deltaTime;
            }

            transform.Translate(carDir * Time.deltaTime * currentSpeed);
        }
        else if(!dialogueStarted && !dialogueDone)
        {
            StartDialogue();
            dialogueStarted = true;
        }


        if (dialogueDone)
        {
            Destroy(gameObject, 7f);
            currentSpeed += 0.6f * Time.deltaTime;
            transform.Translate(carDir * Time.deltaTime * currentSpeed);
        }

        if (!DialogueManager.Instance.IsDialogueActive() && dialogueStarted)
        {
            Despawn();
        }
        
    }
    public void StartDialogue()
    {
        DialogueManager.Instance.StartDialogue(name, dialogue.RootNode);
    }

    public void Despawn()
    {
        dialogueDone = true;
        dialogueStarted = false;
        SpawnCustomer.instance.nextCustomer(); 
    }
}
