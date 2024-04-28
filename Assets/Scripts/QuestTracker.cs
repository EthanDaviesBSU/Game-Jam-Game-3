using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTracker : MonoBehaviour
{
    private Rigidbody2D _RigidBody;
    private int chickenQuest = 0;

    public Dialogue chickenDialogue;
    public Dialogue nestDialogue;
    public Dialogue fergDialogue;
    public Dialogue rabbitDialogue;
    public Dialogue catDialogue;

    public bool bobComplete = false;
    public bool chickenComplete = false;
    public bool fergComplete = false;
    public bool catComplete = false;
    public bool rabbitComplete = false;
    public bool goatComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        _RigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Egg")
        {
            collision.gameObject.SetActive(false);
            chickenQuest++;
            if (chickenQuest == 6)
            {
                chickenQuestEnd();
            }
        }
    }

    public void bobQuestEnd()
    {
        bobComplete = true;
    }

    public void TriggerDialogue(Dialogue dialogue)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    void chickenQuestEnd()
    {
        chickenComplete = true;
        TriggerDialogue(chickenDialogue);
    }

    public void nestMessage()
    {    
        if (chickenQuest == 6)
        {
            TriggerDialogue(nestDialogue);
        }
    }

    public void fergQuestEnd()
    {
        fergComplete = true;
        TriggerDialogue(fergDialogue);
    }

    public void rabbitQuestEnd()
    {
        rabbitComplete = true;
        TriggerDialogue(rabbitDialogue);
    }

    public void catQuestEnd()
    {
        catComplete = true;
        TriggerDialogue(catDialogue);
    }
}
