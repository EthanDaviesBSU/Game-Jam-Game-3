using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTracker : MonoBehaviour
{
    private Rigidbody2D _RigidBody;
    private int chickenQuest = 0;

    public Dialogue chickenDialogue;
    public Dialogue nestDialogue;

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

    public void TriggerDialogue(Dialogue dialogue)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    void chickenQuestEnd()
    {
        TriggerDialogue(chickenDialogue);
    }

    public void nestMessage()
    {    
        if (chickenQuest == 6)
        {
            TriggerDialogue(nestDialogue);
        }
    }
}
