using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public GameObject objActivate;
    public DialogManager dialogManager;
    public string[] mySentences;
    public bool finalDialog;
    void Start()
    {
        if(objActivate != null)
        {
            objActivate.SetActive(false);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            dialogManager.sentences = mySentences;
            dialogManager.index = 0;
            if (finalDialog)
            {
                dialogManager.StartCoroutine("TypeWithFire");
            }
            else
            {
                dialogManager.StartCoroutine("Type");
            }
            
            dialogManager.objToActivate = objActivate;
            Destroy(gameObject);
        }
        
    }


}
