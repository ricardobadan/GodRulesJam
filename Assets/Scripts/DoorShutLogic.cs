using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorShutLogic : MonoBehaviour
{
    public DoorLogic doorLogic;
    public DialogManager dialogManager;
    //public GameLogic gameLogic;
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
            doorLogic.canShut = true;
        }

    }
}
