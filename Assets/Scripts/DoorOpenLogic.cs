using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenLogic : MonoBehaviour
{
    public DoorLogic doorLogic;
    public DialogManager dialogManager;
    public GameLogic gameLogic;
    public GameObject levelChunk;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(dialogManager.canFire && collision.tag == "Player")
        {
            doorLogic.canOpen = true;
            gameLogic.ActivateChunk(levelChunk);
        }
    }
}
